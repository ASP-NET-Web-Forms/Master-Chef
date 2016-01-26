namespace MasterChef.Web.Article
{
    using System;
    using System.Linq;
    using System.Web;

    public partial class Details : BaseAuthorizationPage
    {
        private int articleId;
        private string loggedUserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            var queryParameterId = Request.QueryString["Id"];

            if (string.IsNullOrEmpty(queryParameterId))
            {
                Response.Redirect("~/Article/Browse");
            }

            bool isCorrectId = int.TryParse(queryParameterId, out this.articleId);
            if (!isCorrectId)
            {
                Response.Redirect("~/Error/404");
            }

            var loggedUserName = HttpContext.Current.User.Identity.Name;
            this.loggedUserId = this.data.Users
                .All()
                .FirstOrDefault(x => x.UserName == loggedUserName)
                .Id;

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            var articleData = data.Articles.Find(articleId);

            if (articleData == null)
            {
                Response.Redirect("~/Error/404");
            }

            var userAlreadyLiked = articleData.Likes.Any(like => like.UserID == this.loggedUserId);

            if (userAlreadyLiked)
            { 
                // TODO: change like button to Unlike
            }

            this.ArticleTitle.InnerText = articleData.Title;
            this.ArticleImage.ImageUrl = ResolveUrl(articleData.Image.Path);
            this.ArticleContent.InnerText = articleData.Content;
            this.ArticleCreatorLink.HRef = ResolveUrl("~/User/Details?id=" + articleData.CreatorID);
            this.ArticleCreatorName.InnerText = articleData.Creator.UserName;
            this.ArticleCreatedOn.InnerText = articleData.CreatedOn.ToString("H:mm:ss - dddd dd/MM/yyyy");

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