namespace MasterChef.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Ingredient
    {
        public Ingredient()
        {
            this.Recipes = new HashSet<Recipe>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public string Measurement { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
