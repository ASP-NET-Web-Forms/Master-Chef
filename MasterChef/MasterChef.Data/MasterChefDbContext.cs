namespace MasterChef.Data
{
    using System;
    using System.Data.Entity;
    using MasterChef.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class MasterChefDbContext : IdentityDbContext<AppUser>, IMasterChefDbContext
    {
        public MasterChefDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Article> Articles { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Ingredient> Ingredients { get; set; }

        public virtual IDbSet<RecipeRating> RecipeRatings { get; set; }

        public virtual IDbSet<Recipe> Recipes { get; set; }

        public static MasterChefDbContext Create()
        {
            return new MasterChefDbContext();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
               .HasMany(e => e.Comments)
               .WithRequired(e => e.Creator)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Image>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Image)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Recipe>()
                .HasMany(e => e.RecipeRatings)
                .WithRequired(e => e.Recipe)
                .WillCascadeOnDelete(false);



        }
    }
}
