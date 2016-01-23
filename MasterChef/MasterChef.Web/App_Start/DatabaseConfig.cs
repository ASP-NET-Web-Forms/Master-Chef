namespace MasterChef.Web
{
    using System.Data.Entity;

    using Data;
    using Data.Migrations;
    
    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MasterChefDbContext, Configuration>());
            MasterChefDbContext.Create().Database.Initialize(true);
        }
        
    }
}