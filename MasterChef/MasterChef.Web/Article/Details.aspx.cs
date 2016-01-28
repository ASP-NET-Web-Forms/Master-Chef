namespace MasterChef.Web.Article
{
    using Controls;
    using System;
    using System.Linq;
    using System.Web;
    using MasterChef.Models.Article;
    using MasterChef.Models.Comment;
    using Models;
    using System.Collections.Generic;
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

            this.ArticleTitle.InnerText = articleData.Title;
            this.ArticleImage.ImageUrl = ResolveUrl(articleData.Image.Path);
            this.ArticleContent.InnerText = articleData.Content;
            this.ArticleCreatorLink.HRef = ResolveUrl("~/User/Details?id=" + articleData.CreatorID);
            this.ArticleCreatorName.InnerText = articleData.Creator.UserName;
            this.ArticleCreatedOn.InnerText = articleData.CreatedOn.ToString("H:mm:ss - dddd dd/MM/yyyy");
            this.LikeControl.Value = articleData.Likes.Count;
            this.LikeControl.UserVote = articleData.Likes.Any(l => l.UserID == loggedUserId);
            this.LikeControl.mustUpdate = true;
            this.CommentControl.ArticleComments = GetComments(articleData);
            this.CommentControl.mustUpdate = true;
        }

        protected void LikeControl_Like(object sender, LikeEventArgs e)
        {
            var articleData = this.data.Articles.Find(articleId);
            if (e.LikeValue)
            {
                ArticleLike like = new ArticleLike()
                {
                    ArticleID = articleId,
                    UserID = loggedUserId
                };

                this.data.ArticleLikes.Add(like);
            }
            else
            {
                var currentUserLike = articleData.Likes.FirstOrDefault(l => l.UserID == loggedUserId);
                if (currentUserLike == null)
                {
                    return;
                }

                this.data.ArticleLikes.Delete(currentUserLike);
            }

            this.data.SaveChanges();

            var control = sender as Likes;
            control.Value = articleData.Likes.Count;
            control.UserVote = e.LikeValue;
            control.mustUpdate = true;
        }

        protected void CommentControl_Comment(object sender, CommentEventArgs e)
        {
            var articleData = this.data.Articles.Find(articleId);
            var comment = new Comment()
            {
                ArticleID = articleId,
                CreatorID = loggedUserId,
                CreatedOn = DateTime.Now,
                Content = e.CommentContent
            };

            this.data.Comments.Add(comment);
            this.data.SaveChanges();

            var control = sender as Comments;
            control.ArticleComments = GetComments(articleData);
            control.mustUpdate = true;
        }

        private List<CommentViewModel> GetComments(Article articleData)
        {
            return articleData.Comments
                .OrderByDescending(c => c.CreatedOn)
                .Select(c => new CommentViewModel()
                {
                    CreatorID = c.CreatorID,
                    Creator = c.Creator.UserName,
                    CreatedOn = c.CreatedOn,
                    Content = c.Content
                })
                .ToList();
        }
    }
}