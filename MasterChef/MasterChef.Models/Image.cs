namespace MasterChef.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        public Image()
        {
            this.Recipes = new HashSet<Recipe>();
            this.Users = new HashSet<AppUser>();
            this.Articles = new HashSet<Article>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Path { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

        public virtual ICollection<AppUser> Users { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}