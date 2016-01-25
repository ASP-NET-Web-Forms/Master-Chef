namespace MasterChef.Models.AppUser
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Comment;
    using Article;
    using Recipe;
    using Country;
    using Image;
    using Common.Constants;
    public class AppUser : IdentityUser
    {
        private ICollection<Comment> comments;
        private ICollection<Article> createdArticles;
        private ICollection<Favorite> favoriteArticles;
        private ICollection<ArticleLike> articleLikes;
        private ICollection<Recipe> recipes;
        private ICollection<RecipeLike> recipeLikes;
        private ICollection<RecipeRating> recipeRatings;

        public AppUser()
        {
            this.comments = new HashSet<Comment>();
            this.createdArticles = new HashSet<Article>();
            this.favoriteArticles = new HashSet<Favorite>();
            this.articleLikes = new HashSet<ArticleLike>();
            this.recipes = new HashSet<Recipe>();
            this.recipeLikes = new HashSet<RecipeLike>();
            this.recipeRatings = new HashSet<RecipeRating>();
        }

        [Required]
        [MinLength(ModelConstants.UserFirstNameMinLength)]
        [MaxLength(ModelConstants.UserFirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(ModelConstants.UserLastNameMinLength)]
        [MaxLength(ModelConstants.UserLastNameMaxLength)]
        public string LastName { get; set; }

        public int CountryID { get; set; }

        public virtual Country Country { get; set; }

        public int ImageID { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Article> CreatedArticles
        {
            get { return this.createdArticles; }
            set { this.createdArticles = value; }
        }

        public virtual ICollection<Favorite> FavoriteArticles
        {
            get { return this.favoriteArticles; }
            set { this.favoriteArticles = value; }
        }

        public virtual ICollection<ArticleLike> ArticleLikes
        {
            get { return this.articleLikes; }
            set { this.articleLikes = value; }
        }

        public virtual ICollection<Recipe> Recipes
        {
            get { return this.recipes; }
            set { this.recipes = value; }
        }

        public virtual ICollection<RecipeLike> RecipeLikes
        {
            get { return this.recipeLikes; }
            set { this.recipeLikes = value; }
        }

        public virtual ICollection<RecipeRating> RecipeRatings
        {
            get { return this.recipeRatings; }
            set { this.recipeRatings = value; }
        }

        public ClaimsIdentity GenerateUserIdentity(UserManager<AppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
