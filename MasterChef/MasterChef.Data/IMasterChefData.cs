namespace MasterChef.Data
{
    using MasterChef.Models;

    public interface IMasterChefData
    {
        IRepository<Article> Articles { get; }

        IRepository<Recipe> Recipes { get; }

        IRepository<RecipeRating> RecepieRatings { get; }

        IRepository<Ingredient> Ingredients { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Country> Countries { get; }

        IRepository<Image> Images { get; }

        IRepository<AppUser> Users { get; }

        int SaveChanges();
    }
}
