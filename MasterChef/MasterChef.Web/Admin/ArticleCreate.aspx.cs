using MasterChef.Data;
using MasterChef.Models.Image;
using MasterChef.Web.User;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace MasterChef.Web.Admin
{
    public partial class ArticleCreate : BaseAdminPage
    {
        private new IMasterChefData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            var dbContext = new MasterChefDbContext();
            this.data = new MasterChefData(dbContext);
        }

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

                Response.Redirect("~/Default");
            }
            else
            {
                throw new InvalidOperationException("Error occured while saving the element!");
            }
        }
    }
}