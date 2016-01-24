namespace MasterChef.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class RecipeRating
    {
        public int ID { get; set; }

        public int RecipeID { get; set; }

        public virtual Recipe Recipe { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserID { get; set; }

        public virtual AppUser User { get; set; }

        public DateTime? RatedOn { get; set; }       
    }
}
