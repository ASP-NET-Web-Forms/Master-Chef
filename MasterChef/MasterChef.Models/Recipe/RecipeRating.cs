namespace MasterChef.Models.Recipe
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AppUser;
    using System.ComponentModel.DataAnnotations.Schema;

    public class RecipeRating
    {
        public int ID { get; set; }
        
        public int RecipeID { get; set; }

        [ForeignKey("RecipeID")]
        public virtual Recipe Recipe { get; set; }

        [Required]
        public int Rating { get; set; }
        
        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual AppUser User { get; set; }

        public DateTime? RatedOn { get; set; }       
    }
}
