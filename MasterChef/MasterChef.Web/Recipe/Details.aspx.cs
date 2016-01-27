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

            this.IngredientsList.DataSource = recipeData.Ingradients;
            this.IngredientsList.DataBind();

            //this.ListViewUsers.DataSource = articleData.UsersEvents
            //    .Select(userEvents => new JoinedUsersViewModel
            //    {
            //        UserName = userEvents.User.UserName,
            //        ID = userEvents.User.Id,
            //        Image = userEvents.User.Image
            //    });

            //this.ListViewUsers.DataBind();
        }
    }
}