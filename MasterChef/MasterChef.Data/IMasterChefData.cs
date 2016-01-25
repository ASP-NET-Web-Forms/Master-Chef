namespace MasterChef.Data
{
    using Models.AppUser;
    using Models.Article;
    using Models.Comment;
    using Models.Country;
    using Models.Image;
    using Models.Ingredient;
    using Models.Recipe;
    using MasterChef.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public interface IMasterChefData
    {
        IRepository<Article> Articles { get; }
        IRepository<Favorite> Favorite { get; }
        IRepository<ArticleLike> ArticleLikes { get; }

        IRepository<Recipe> Recipes { get; }
        IRepository<RecipeLike> RecipeLikes { get; }
        IRepository<RecipeRating> RecipeRatings { get; }

        IRepository<Ingredient> Ingredients { get; }
        IRepository<IngredientName> IngredientNames { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Country> Countries { get; }

        IRepository<Image> Images { get; }

        IRepository<AppUser> Users { get; }

        IRepository<IdentityRole> Roles { get; }

        int SaveChanges();
    }
}
