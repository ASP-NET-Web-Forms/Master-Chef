namespace MasterChef.Web
{
    using System.Web;
    using System.Web.UI;

    public abstract class BaseAuthorizationPage : Page
    {
        public BaseAuthorizationPage()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                HttpContext.Current.Response.Redirect("~/");
            }
        }
    }
}