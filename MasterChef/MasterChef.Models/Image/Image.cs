namespace MasterChef.Models.Image
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Recipe;
    using AppUser;
    using Article;

    public class Image
    {
        private ICollection<Recipe> recipes;
        private ICollection<AppUser> users;
        private ICollection<Article> articles;

        public Image()
        {
            this.recipes = new HashSet<Recipe>();
            this.users = new HashSet<AppUser>();
            this.articles = new HashSet<Article>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Path { get; set; }

        public virtual ICollection<Recipe> Recipes
        {
            get { return this.recipes; }
            set { this.recipes = value; }
        }

        public virtual ICollection<AppUser> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public virtual ICollection<Article> Articles
        {
            get { return this.articles; }
            set { this.articles = value; }
        }
    }
}