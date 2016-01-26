namespace DrinkAndRate.Web.User
{
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using Microsoft.AspNet.EntityDataSource;
    using MasterChef.Data;

    public abstract class BaseAdminPage : Page
    {
        protected IMasterChefDbContext dbContext;
        protected IMasterChefData data;

        public BaseAdminPage()
        {
            dbContext = new MasterChefDbContext();
            data = new MasterChefData(dbContext);

            bool isAuthenticatedAndAdmin = this.User.Identity.IsAuthenticated;

            if (isAuthenticatedAndAdmin)
            {
                var user = data.Users.All()
                    .Single(x => x.UserName == this.Context.User.Identity.Name);
                var adminRole = data.Roles.All()
                    .Single(x => x.Name == "admin");

                isAuthenticatedAndAdmin = user.Roles.Any(role => role.RoleId == adminRole.Id);
            }

            if (!isAuthenticatedAndAdmin)
            {
                HttpContext.Current.Response.Redirect("~/");
            }
        }

        protected void dataSource_ContextCreating(object sender, EntityDataSourceContextCreatingEventArgs e)
        {
            e.Context = (new MasterChefDbContext() as IObjectContextAdapter).ObjectContext;
        }
    }
}