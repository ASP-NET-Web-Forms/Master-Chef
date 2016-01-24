namespace MasterChef.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Recipe
    {
        public Recipe()
        {
            this.RecipeRatings = new HashSet<RecipeRating>();
            this.Ingradients = new HashSet<Ingredient>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
     
        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey("Creator")]
        public string CreatorID { get; set; }

        public virtual AppUser Creator { get; set; }

        public int ImageID { get; set; }

        public virtual Image Image { get; set; }

        public bool isCold { get; set; }

        public bool isHot { get; set; }

        public bool isSweet { get; set; }

        public bool isVegitarian { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int likes { get; set; }

        public virtual ICollection<RecipeRating> RecipeRatings { get; set; }

        public virtual ICollection<Ingredient> Ingradients { get; set; }
    }
}
