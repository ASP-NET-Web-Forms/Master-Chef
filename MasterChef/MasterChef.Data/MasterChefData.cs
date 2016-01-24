using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterChef.Models;

namespace MasterChef.Data
{
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

        public IRepository<RecipeRating> RecepieRatings
        {
            get
            {
                return this.GetRepository<RecipeRating>();
            }
        }

        public IRepository<Recipe> Recipes
        {
            get
            {
                return this.GetRepository<Recipe>();
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
