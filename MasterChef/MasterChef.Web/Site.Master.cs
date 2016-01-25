namespace MasterChef.Web
{
    using System;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Microsoft.AspNet.Identity;
    using MasterChef.Data;
    using System.Linq;
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        private IMasterChefData data;
        private string currentUserID;
        protected string currentUserImagePath;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var currentUserId = Request.QueryString["Id"];

            var dbContext = new MasterChefDbContext();
            this.data = new MasterChefData(dbContext);

            if (Context.User.Identity.IsAuthenticated)
            {
                var user = this.data.Users
                    .All()
                    .Where(u => u.UserName == this.Context.User.Identity.Name)
                    .FirstOrDefault();

                var adminRole = this.data.Roles
                    .All()
                    .Where(r => r.Name == "admin")
                    .FirstOrDefault();

                if (user.Roles.Any(r => r.RoleId == adminRole.Id))
                {
                    // TODO: show admin nav bar
                }

                (LoginView.FindControl("ProfileImage") as Image).ImageUrl = user.Image.Path;

                // TODO: cache data using this.Cache -> sitemaster
            }
            else
            {
                AddRecipePrivateItemMenu.Attributes.CssStyle.Add(HtmlTextWriterStyle.Display, "none");
                FavouriteArticlesPrivateItemMenu.Attributes.CssStyle.Add(HtmlTextWriterStyle.Display, "none");
                MyRecipesPrivateItemMenu.Attributes.CssStyle.Add(HtmlTextWriterStyle.Display, "none");
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }

}