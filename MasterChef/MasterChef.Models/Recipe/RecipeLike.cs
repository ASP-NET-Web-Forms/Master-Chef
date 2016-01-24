namespace MasterChef.Models.Recipe
{
    using AppUser;

    public class RecipeLike
    {
        public int ID { get; set; }

        public string AppUserID { get; set; }

        public virtual AppUser AppUser { get; set; }

        public int RecipeID { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
