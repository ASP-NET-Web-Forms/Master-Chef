namespace MasterChef.Models.Recipe
{
    using AppUser;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class RecipeLike
    {
        public int ID { get; set; }
        
        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual AppUser User { get; set; }
        
        public int RecipeID { get; set; }

        [ForeignKey("RecipeID")]
        public virtual Recipe Recipe { get; set; }
    }
}
