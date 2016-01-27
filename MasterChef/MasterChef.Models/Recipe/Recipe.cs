namespace MasterChef.Models.Recipe
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Ingredient;
    using AppUser;
    using Image;
    using Common.Constants;

    public class Recipe
    {
        private ICollection<RecipeLike> likes;
        private ICollection<RecipeRating> ratings;
        private ICollection<Ingredient> ingredients;

        public Recipe()
        {
            this.likes = new HashSet<RecipeLike>();
            this.ratings = new HashSet<RecipeRating>();
            this.ingredients = new HashSet<Ingredient>();
        }

        public int ID { get; set; }

        [Required]
        [MinLength(ModelConstants.RecipeNameMinLength)]
        [MaxLength(ModelConstants.RecipeNameMaxLength)]
        public string Name { get; set; }

        [MinLength(ModelConstants.RecipeDescriptionMinLength)]
        [MaxLength(ModelConstants.RecipeDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        
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

        public virtual ICollection<RecipeLike> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }

        public virtual ICollection<RecipeRating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public virtual ICollection<Ingredient> Ingredients
        {
            get { return this.ingredients; }
            set { this.ingredients = value; }
        }
    }
}
