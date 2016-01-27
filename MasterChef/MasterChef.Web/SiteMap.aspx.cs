using MasterChef.Data;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace MasterChef.Web
{
    public partial class SiteMap : System.Web.UI.Page
    {
        private bool _isAdmin;

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.FindControl("panelSiteMapPath").Visible = false;

            if (Context.User.Identity.IsAuthenticated)
            {
                var dbContext = new MasterChefDbContext();
                var data = new MasterChefData(dbContext);

                var user = data.Users.All()
                    .Single(x => x.UserName == this.Context.User.Identity.Name);
                var adminRole = data.Roles.All()
                    .Single(x => x.Name == "admin");

                if (user.Roles.Any(role => role.RoleId == adminRole.Id))
                {
                    this._isAdmin = true;
                }
            }
        }

        protected void TreeViewSitePages_TreeNodeDataBound(object sender, TreeNodeEventArgs e)
        {
            if (!ShouldShowItem(e.Node.Text))
            {
                e.Node.Parent.ChildNodes.Remove(e.Node);
            }
        }

        private bool ShouldShowItem(string menuText)
        {
            return menuText == "Master Chef" ||
                this.User.Identity.IsAuthenticated && !menuText.EndsWith("Grid") ||
                this._isAdmin;
        }
    }
}