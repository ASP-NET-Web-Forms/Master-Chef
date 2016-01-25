namespace MasterChef.Data
{
    using System;
    using System.Collections.Generic;
    using MasterChef.Models.Article;
    using MasterChef.Models.Comment;
    using MasterChef.Models.Country;
    using MasterChef.Models.Image;
    using MasterChef.Models.Ingredient;
    using MasterChef.Models.Recipe;
    using MasterChef.Models.AppUser;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class MasterChefData : IMasterChefData
    {
        private IMasterChefDbContext context;
        private IDictionary<Type, object> repositories;

        public MasterChefData(IMasterChefDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Article> Articles
        {
            get
            {
                return this.GetRepository<Article>();
            }
        }

        public IRepository<Favorite> Favorite
        {
            get
            {
                return this.GetRepository<Favorite>();
            }
        }

        public IRepository<ArticleLike> ArticleLikes
        {
            get
            {
                return this.GetRepository<ArticleLike>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IRepository<Country> Countries
        {
            get
            {
                return this.GetRepository<Country>();
            }
        }

        public IRepository<Image> Images
        {
            get
            {
                return this.GetRepository<Image>();
            }
        }

        public IRepository<Ingredient> Ingredients
        {
            get
            {
                return this.GetRepository<Ingredient>();
            }
        }

        public IRepository<IngredientName> IngredientNames
        {
            get
            {
                return this.GetRepository<IngredientName>();
            }
        }

        public IRepository<Recipe> Recipes
        {
            get
            {
                return this.GetRepository<Recipe>();
            }
        }

        public IRepository<RecipeLike> RecipeLikes
        {
            get
            {
                return this.GetRepository<RecipeLike>();
            }
        }

        public IRepository<RecipeRating> RecipeRatings
        {
            get
            {
                return this.GetRepository<RecipeRating>();
            }
        }

        public IRepository<IdentityRole> Roles
        {
            get
            {
                return this.GetRepository<IdentityRole>();
            }
        }

        public IRepository<AppUser> Users
        {
            get
            {
                return this.GetRepository<AppUser>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
