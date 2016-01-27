namespace MasterChef.Web.Recipe
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Linq;
    using Subgurim.Controles;
    using User;
    using MasterChef.Models.Ingredient;
    using MasterChef.Models.Image;
    using MasterChef.Models.Recipe;

    public partial class Create : BaseAuthorizationPage
    {
        private bool isHotDish = false;
        private bool isColdDish = false;
        private bool isSweetDish = false;
        private bool isVegetarianDish = false;
        private string[] coordinates;

        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeGoogleMaps();
        }

        private void InitializeGoogleMaps()
        {
            GMap1.Add(new GMapUI());

            GMapUIOptions options = new GMapUIOptions();
            options.maptypes_hybrid = false;
            options.keyboard = false;
            options.maptypes_physical = false;
            options.zoom_scrollwheel = true;

            GMap1.Add(new GMapUI(options));

            GControl control = new GControl(GControl.preBuilt.LargeMapControl);
            GControl control2 = new GControl(GControl.preBuilt.MenuMapTypeControl, new GControlPosition(GControlPosition.position.Top_Right));

            GMap1.Add(control);
            GMap1.Add(control2);

            GMap1.Add(new GControl(GControl.preBuilt.GOverviewMapControl, new GControlPosition(GControlPosition.position.Bottom_Left)));
        }

        protected string OnGoogleMapClick(object s, GAjaxServerEventArgs e)
        {
            GMarker marker = new GMarker(e.point);

            GInfoWindow window = new GInfoWindow(marker,
                                                 string.Format(
                                                     @"<b>GLatLngBounds</b><br/>NE = {0}",
                                                     e.bounds.getNorthEast()),
                                                 true);

            this.coordinates = e.bounds.getNorthEast().ToString().Split(',');
            return window.ToString(e.map);
            
        }

        protected void OnCreateRecipeButtonClick(object sender, EventArgs e)
        {
            var loggedInUserName = HttpContext.Current.User.Identity.Name;
            var currentUserId = this.data.Users.All().FirstOrDefault(x => x.UserName == loggedInUserName).Id;
            var ingredientsForRecipe = GetIngredients(this.RecipeIngredients.Text);

            Recipe recipe = new Recipe()
            {
                Name = this.RecipeName.Text,
                Description = this.RecipeDescription.Text,
                CreatedOn = DateTime.Now,
                CreatorID = currentUserId,
                isHot = this.isHotDish,
                isCold = this.isColdDish,
                isSweet = this.isSweetDish,
                isVegitarian = this.isVegetarianDish,
                Latitude = 41.124588,
                Longitude = 13.713464,
                Ingradients = ingredientsForRecipe
            };
            

            string filePathAndName = string.Empty;

            try
            {
                filePathAndName = FileUploadControl.Upload();
            }
            catch (InvalidOperationException ex)
            {
                this.DivLabelErrorMessage.Visible = true;
                this.LabelErrorMessage.Text = ex.Message;

                return;
            }

            if (string.IsNullOrEmpty(filePathAndName))
            {
                recipe.ImageID = this.data.Images.All().FirstOrDefault().ID;
            }
            else
            {
                var image = new Image { Path = filePathAndName };
                this.data.Images.Add(image);
                recipe.Image = image;
            }

            this.data.Recipes.Add(recipe);
            this.data.SaveChanges();

            Response.Redirect("~/User/MyRecipes");
        }

        private ICollection<Ingredient> GetIngredients(string text)
        {
            var ingredients = new List<Ingredient>();
            var stringSeparators = new string[] { ", " };
            var charSeparators = new char[] { '[', ']' };

            var splittedText = text.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < splittedText.Length; i++)
            {
                var splittedIngredient = splittedText[i].Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                string name = splittedIngredient[0];
                string quantityString = splittedIngredient[1];
                int quantityStringDotIndex = quantityString.IndexOf('.');
                int quantityStringCommaIndex = quantityString.IndexOf(',');

                int quantity = 0;
                if (!int.TryParse(splittedIngredient[1], out quantity))
                {
                    if (splittedIngredient[1].IndexOf('/') > -1)
                    {
                        var quantitySplitted = splittedIngredient[1].Split('/').Select(q => int.Parse(q)).ToArray();
                        if (quantitySplitted[1] == 0)
                        {
                            continue;
                        }

                        quantity = quantitySplitted[0] / quantitySplitted[1];
                    }
                    else if (quantityStringDotIndex > -1)
                    {
                        quantity = int.Parse(quantityString.Substring(0, quantityStringDotIndex));
                    }
                    else if (splittedIngredient[1].IndexOf(',') > -1)
                    {
                        quantity = int.Parse(quantityString.Substring(0, quantityStringCommaIndex));
                    }
                    else
                    {
                        // TODO: maybe throw error?
                        continue;
                    }
                }

                var ingredient = new Ingredient()
                {
                    Name = name,
                    Quantity = quantity,
                    Measurement = "gr",
                    CreatedOn = DateTime.Now
                };

                this.data.Ingredients.Add(ingredient);
                ingredients.Add(ingredient);
            }

            return ingredients;
        }

        protected void isHot_CheckedChanged(object sender, EventArgs e)
        {
            this.isHotDish = true;
            this.isColdDish = false;
        }

        protected void isCold_CheckedChanged(object sender, EventArgs e)
        {
            this.isColdDish = true;
            this.isHotDish = false;
        }

        protected void isSweet_CheckedChanged(object sender, EventArgs e)
        {
            this.isSweetDish = true;
        }

        protected void isVegetarian_CheckedChanged(object sender, EventArgs e)
        {
            this.isVegetarianDish = true;
        }
    }
}