namespace MasterChef.Web.Error
{
    using System;

    public partial class _403 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorImage.ImageUrl = ResolveUrl("~/Error/403.gif");
        }
    }
}