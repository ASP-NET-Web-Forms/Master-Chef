namespace MasterChef.Models.Ingredient
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Recipe;
    using Common.Constants;

    public class Ingredient
    {
        private ICollection<Recipe> recipes;

        public Ingredient()
        {
            this.recipes = new HashSet<Recipe>();
        }

        public int ID { get; set; }

        public int NameID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(ModelConstants.IngredientQuantityMinValue, ModelConstants.IngredientQuantityMaxValue)]
        public int Quantity { get; set; }

        [Required]
        public string Measurement { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Recipe> Recipes
        {
            get { return this.recipes; }
            set { this.recipes = value; }
        }
    }
}
