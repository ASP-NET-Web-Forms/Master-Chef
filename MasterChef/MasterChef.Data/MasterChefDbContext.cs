namespace MasterChef.Data
{
    using MasterChef.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class MasterChefDbContext : IdentityDbContext<AppUser>
    {
        public MasterChefDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static MasterChefDbContext Create()
        {
            return new MasterChefDbContext();
        }
    }
}
