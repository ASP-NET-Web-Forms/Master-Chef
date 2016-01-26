namespace MasterChef.Web.User
{
    using System;

    using Subgurim.Controles;
    using Data;
    using MasterChef.Models.Ingredient;
    using System.Collections.Generic;
    using MasterChef.Models.Recipe;
    using System.Web;
    using System.Linq;
    using MasterChef.Models.Image;
    public partial class RecipeCreate : System.Web.UI.Page
    {
        private IMasterChefData data;
        private bool isHotDish = false;
        private bool isColdDish = false;
        private bool isSweetDish = false;
        private bool isVegetarianDish = false;
        private string[] coordinates;

        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeGoogleMaps();

            var dbContext = new MasterChefDbContext();
            this.data = new MasterChefData(dbContext);
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
                Ingradients = GetIngredients(this.RecipeIngredients.Text)
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
                recipe.ImageID = this.data.Images.Find(1).ID;
            }
            else
            {
                recipe.Image = new Image { Path = filePathAndName };
            }

            this.data.Recipes.Add(recipe);
            this.data.SaveChanges(); // Need to fix bug on SaveChanges()
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

        private IList<Ingredient> GetIngredients(string text)
        {
            var ingredients = new List<Ingredient>();

            var splittedText = text.Split(',');

            for (int i = 0; i < splittedText.Length; i++)
            {
                var splittedIngredient = splittedText[i].Split(' ');
                string name = splittedIngredient[0];
                int quantity = int.Parse(splittedIngredient[1]);

                var ingredient = new Ingredient()
                {
                    Name = name,
                    Quantity = quantity,
                    Measurement = "gr",
                    CreatedOn = DateTime.Now
                };

                this.data.Ingredients.Add(ingredient);
                this.data.SaveChanges();
                ingredients.Add(ingredient);
            }            

            return ingredients;
        }
    }
}