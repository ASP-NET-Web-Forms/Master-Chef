namespace MasterChef.Data
{
    using MasterChef.Models;
    using Models.AppUser;
    using Models.Article;
    using Models.Comment;
    using Models.Country;
    using Models.Image;
    using Models.Ingredient;
    using Models.Recipe;
    public interface IMasterChefData
    {
        IRepository<Article> Articles { get; }
        IRepository<ArticleLike> ArticleLikes { get; }

        IRepository<Recipe> Recipes { get; }
        IRepository<RecipeLike> RecipeLikes { get; }
        IRepository<RecipeRating> RecipeRatings { get; }

        IRepository<Ingredient> Ingredients { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Country> Countries { get; }

        IRepository<Image> Images { get; }

        IRepository<AppUser> Users { get; }

        int SaveChanges();
    }
}
