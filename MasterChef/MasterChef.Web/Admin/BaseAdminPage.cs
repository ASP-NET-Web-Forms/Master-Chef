namespace MasterChef.Web.User
{
    using MasterChef.Data;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Web;
    using System.Web.UI;

    public abstract class BaseAdminPage : Page
    {
        protected IMasterChefDbContext dbContext;
        protected IMasterChefData data;

        public BaseAdminPage()
        {
            dbContext = new MasterChefDbContext();
            data = new MasterChefData(dbContext);

            bool isAuthenticated = this.User.Identity.IsAuthenticated;

            if (isAuthenticated)
            {
                var user = data.Users.All()
                    .Single(x => x.UserName == this.Context.User.Identity.Name);
                var adminRole = data.Roles.All()
                    .Single(x => x.Name == "admin");

                bool isAdmin = user.Roles.Any(role => role.RoleId == adminRole.Id);
                if (!isAdmin)
                {
                    HttpContext.Current.Response.Redirect("~/Error/403");
                }
            }
        }

        protected void dataSource_ContextCreating(object sender, Microsoft.AspNet.EntityDataSource.EntityDataSourceContextCreatingEventArgs e)
        {
            e.Context = (new MasterChefDbContext() as IObjectContextAdapter).ObjectContext;
        }
    }
}