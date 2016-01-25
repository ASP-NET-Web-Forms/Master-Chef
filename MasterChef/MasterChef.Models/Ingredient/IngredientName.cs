namespace MasterChef.Models.Ingredient
{
    using MasterChef.Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class IngredientName
    {
        public int ID { get; set; }

        [Required]
        [MinLength(ModelConstants.IngredientNameMinLength)]
        [MaxLength(ModelConstants.IngredientNameMaxLength)]
        public string Name { get; set; }
    }
}
