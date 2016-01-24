namespace MasterChef.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models.Article;
    using Models.Recipe;
    using Models.Ingredient;
    using Models.Comment;
    using Models.Country;
    using Models.Image;
    using Models.AppUser;

    public interface IMasterChefDbContext : IDisposable
    {
        IDbSet<Article> Articles { get; set; }
        IDbSet<ArticleLike> ArticleLikes { get; set; }

        IDbSet<Recipe> Recipes { get; set; }
        IDbSet<RecipeLike> RecipeLikes { get; set; }
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
