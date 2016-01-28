using MasterChef.Models.Recipe;
using MasterChef.Web.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MasterChef.Web.Recipe
{
    public partial class Details : BaseAuthorizationPage
    {
        private int recipeId;
        private string loggedUserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            var queryParameterId = Request.QueryString["Id"];

            if (string.IsNullOrEmpty(queryParameterId))
            {
                Response.Redirect("~/Recipe/Browse");
            }

            bool isCorrectId = int.TryParse(queryParameterId, out this.recipeId);
            if (!isCorrectId)
            {
                Response.Redirect("~/Error/404");
            }

            var loggedUserName = HttpContext.Current.User.Identity.Name;
            this.loggedUserId = this.data.Users.All().FirstOrDefault(x => x.UserName == loggedUserName).Id;

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            var recipeData = data.Recipes.Find(this.recipeId);

            if (recipeData == null)
            {
                Response.Redirect("~/Error/404");
            }

            var userAlreadyLiked = recipeData.Likes.Any(like => like.UserID == this.loggedUserId);

            if (userAlreadyLiked)
            {
                // TODO: change like button to Unlike
            }

            this.ArticleTitle.InnerText = recipeData.Name;
            this.ArticleImage.ImageUrl = ResolveUrl(recipeData.Image.Path);
            this.ArticleContent.InnerText = recipeData.Description;
            this.ArticleCreatorLink.HRef = ResolveUrl("~/User/Details?id=" + recipeData.CreatorID);
            this.ArticleCreatorName.InnerText = recipeData.Creator.UserName;
            this.ArticleCreatedOn.InnerText = recipeData.CreatedOn.ToString("H:mm:ss - dddd dd/MM/yyyy");

            this.isHotDish.Visible = recipeData.isHot;
            this.isColdDish.Visible = recipeData.isCold;
            this.isSweetDish.Visible = recipeData.isSweet;
            this.isVegetarianDish.Visible = recipeData.isVegitarian;

            this.IngredientsList.DataSource = recipeData.Ingredients;
            this.IngredientsList.DataBind();

            this.LikeControl.Value = recipeData.Likes.Count;
            this.LikeControl.UserVote = recipeData.Likes.Any(l => l.UserID == this.loggedUserId);
            this.LikeControl.mustUpdate = true;

            var recipeRating = 0.0;
            if (recipeData.Ratings.Count > 0)
            {
                recipeRating = (double)recipeData.Ratings.Sum(r => r.Rating) / recipeData.Ratings.Count;
            }

            this.RateControl.Value = Convert.ToInt32(Math.Ceiling(recipeRating));
            this.RateControl.UserVote = recipeData.Ratings.Any(l => l.UserID == this.loggedUserId);
            this.RateControl.mustUpdate = true;
        }

        protected void LikeControl_Like(object sender, LikeEventArgs e)
        {
            var recipeData = this.data.Recipes.Find(recipeId);
            if (e.LikeValue)
            {
                RecipeLike like = new RecipeLike()
                {
                    RecipeID = recipeId,
                    UserID = this.loggedUserId
                };

                this.data.RecipeLikes.Add(like);
            }
            else
            {
                var currentUserLike = recipeData.Likes.FirstOrDefault(l => l.UserID == this.loggedUserId);
                if (currentUserLike == null)
                {
                    return;
                }

                this.data.RecipeLikes.Delete(currentUserLike);
            }

            this.data.SaveChanges();

            var control = sender as Likes;
            control.Value = recipeData.Likes.Count;
            control.UserVote = e.LikeValue;
            control.mustUpdate = true;
        }

        protected void RateControl_Rate(object sender, RateEventArgs e)
        {
            var recipeData = this.data.Recipes.Find(recipeId);
            RecipeRating rating = new RecipeRating()
            {
                RecipeID = recipeId,
                UserID = this.loggedUserId,
                Rating = e.RateValue,
                RatedOn = DateTime.Now
            };

            this.data.RecipeRatings.Add(rating);
            this.data.SaveChanges();

            var control = sender as Rates;
            var recipeRating = 0.0;
            if (recipeData.Ratings.Count > 0)
            {
                recipeRating = (double)recipeData.Ratings.Sum(r => r.Rating) / recipeData.Ratings.Count;
            }

            this.RateControl.Value = Convert.ToInt32(Math.Ceiling(recipeRating));
            this.RateControl.UserVote = true;
            this.RateControl.mustUpdate = true;
        }
    }
}