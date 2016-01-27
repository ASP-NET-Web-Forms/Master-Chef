namespace MasterChef.Web.Account
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Microsoft.AspNet.Identity;
    using MasterChef.Data;
    using MasterChef.Models.AppUser;
    using System.Linq;
    using MasterChef.Common.Constants;

    public partial class EditProfile : Page
    {
        private IMasterChefData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            var dbContext = new MasterChefDbContext();
            this.data = new MasterChefData(dbContext);

            string userId = this.User.Identity.GetUserId();
            AppUser user = data.Users.All().Single(x => x.Id == userId);
            this.details.DataSource = new List<AppUser>() { user };
            this.details.DataBind();
        }

        protected void UpdateUser_Click(object sende, EventArgs e)
        {
            string userId = this.User.Identity.GetUserId();
            AppUser user = data.Users.All().Single(x => x.Id == userId);

            string newFirstName = this.GetTextFromInnerControl(this.details, "tbFirstName");
            string newLastName = this.GetTextFromInnerControl(this.details, "tbLastName");
            string newEmail = this.GetTextFromInnerControl(this.details, "tbEmail");

            user.FirstName = newFirstName != null ? newFirstName : user.FirstName;
            user.LastName = newLastName != null ? newLastName : user.LastName;
            user.Email = newEmail != null ? newEmail : user.Email;

            FileUpload fileUpload = this.details.FindControl("fileAvatar") as FileUpload;
            if (fileUpload == null || !fileUpload.HasFile ||
                !fileUpload.PostedFile.ContentType.Contains("image"))
            {
                string newAvatarUrl = this.GetTextFromInnerControl(this.details, "tbAvatar");
                user.Image.Path = string.IsNullOrWhiteSpace(newAvatarUrl) ? SiteConstants.DefaultAvatar : newAvatarUrl;
            }
            else
            {
                if (fileUpload.PostedFile.ContentLength > SiteConstants.ImageMaxSize)
                {
                    this.panel.Visible = true;
                    this.errorText.InnerHtml = string.Format(
                        SiteConstants.ErrorUploadMessageFormat,
                        SiteConstants.ImageMaxSize / (1000.0 * 1000.0));
                    return;
                }

                string filename = Path.GetFileNameWithoutExtension(fileUpload.FileName);
                string extension = Path.GetExtension(fileUpload.FileName);
                string path = Server.MapPath(SiteConstants.DefaultImagePath);
                filename += DateTime.Now.ToString(SiteConstants.DateFormatForFileNameImages) + extension;
                fileUpload.SaveAs(path + filename);
                user.Image.Path = SiteConstants.PublicPathImages + filename;
            }

            string errorMessage = this.ValidateUser(user);
            if (errorMessage != null)
            {
                this.panel.Visible = true;
                this.errorText.InnerHtml = errorMessage;
                return;
            }

            this.data.Users.Update(user);
            this.data.SaveChanges();

            this.Response.Redirect("~/Account/Manage");
        }

        private string GetTextFromInnerControl(Control control, string innerControlID)
        {
            TextBox field = control.FindControl(innerControlID) as TextBox;
            if (field == null)
            {
                return null;
            }

            return field.Text.Trim();
        }

        private string ValidateUser(AppUser user)
        {
            if (user.FirstName.Length < ModelConstants.UserFirstNameMinLength ||
                user.LastName.Length < ModelConstants.UserLastNameMinLength)
            {
                return SiteConstants.ErrorFieldMinLength;
            }

            if (user.FirstName.Length > ModelConstants.UserFirstNameMaxLength ||
                 user.LastName.Length > ModelConstants.UserLastNameMaxLength)
            {
                return SiteConstants.ErrorFieldMaxLength;
            }

            if (!new Regex(SiteConstants.EmailRegex).IsMatch(user.Email))
            {
                return SiteConstants.WrongEmailAddress;
            }

            return null;
        }
    }
}