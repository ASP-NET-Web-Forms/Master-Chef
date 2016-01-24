namespace MasterChef.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using MasterChef.Models;

    public interface IMasterChefDbContext : IDisposable
    {
        IDbSet<Article> Articles { get; set; }

        IDbSet<Recipe> Recipes { get; set; }

        IDbSet<RecipeRating> RecipeRatings { get; set; }

        IDbSet<Ingredient> Ingredients { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<AppUser> Users { get; set; }

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
