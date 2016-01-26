namespace MasterChef.Web.Admin
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using MasterChef.Models.Image;
    using MasterChef.Web.User;

    public partial class ArticleCreate : BaseAdminPage
    {
        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
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

                var loggedInUserName = HttpContext.Current.User.Identity.Name;
                var currentUserId = this.data.Users.All().FirstOrDefault(x => x.UserName == loggedInUserName).Id;

                var newImage = new Image
                {
                    Path = filePathAndName
                };

                this.data.Images.Add(newImage);
                this.data.SaveChanges();

                var newArticle = new MasterChef.Models.Article.Article
                {
                    Title = this.title.Value,
                    ImageID = newImage.ID,
                    Content = this.content.Value,
                    CreatedOn = DateTime.Now,
                    CreatorID = currentUserId
                };

                this.data.Articles.Add(newArticle);

                this.data.SaveChanges();

                Response.Redirect("~/Article/Browse");
            }
            else
            {
                throw new InvalidOperationException("Error occured while saving the element!");
            }
        }
    }
}