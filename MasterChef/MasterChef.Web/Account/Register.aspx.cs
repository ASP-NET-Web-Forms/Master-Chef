using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MasterChef.Models.AppUser;
using Owin;
using MasterChef.Models;
using MasterChef.Data;
using MasterChef.Models.Image;

namespace MasterChef.Web.Account
{
    public partial class Register : Page
    {
        private IMasterChefData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            var dbContext = new MasterChefDbContext();
            this.data = new MasterChefData(dbContext);

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = new AppUser()
            {
                UserName = Email.Text,
                Email = Email.Text,
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                CountryID = int.Parse(Countries.SelectedValue)
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
                user.ImageID = this.data.Images.All().FirstOrDefault().ID;
            }
            else
            {
                user.Image = new Image { Path = filePathAndName };
            }

            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                manager.AddToRole(user.Id, "user");
                IdentityHelper.SignIn(manager, user, isPersistent: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        private void LoadData()
        {
            var allCountries = this.data.Countries.All().ToList();
            this.Countries.DataSource = allCountries;
            this.Countries.DataBind();
        }
    }
}