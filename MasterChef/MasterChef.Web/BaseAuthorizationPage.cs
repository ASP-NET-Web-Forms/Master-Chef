namespace MasterChef.Web
{
    using System.Web;
    using System.Web.UI;
    using System.Data.Entity.Infrastructure;
    using Data;

    public abstract class BaseAuthorizationPage : Page
    {
        protected IMasterChefDbContext dbContext;
        protected IMasterChefData data;

        public BaseAuthorizationPage()
        {
            this.dbContext = new MasterChefDbContext();
            this.data = new MasterChefData(dbContext);

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                HttpContext.Current.Response.Redirect("~/Account/Login");
            }
        }

        protected void dataSource_ContextCreating(object sender, Microsoft.AspNet.EntityDataSource.EntityDataSourceContextCreatingEventArgs e)
        {
            e.Context = (new MasterChefDbContext() as IObjectContextAdapter).ObjectContext;
        }
    }
}