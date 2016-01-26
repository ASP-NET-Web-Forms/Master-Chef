namespace MasterChef.Web.Models
{
    using System;

    public class RecipeViewModel
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public string CreatorID { get; set; }

        public string Creator { get; set; }

        public string ImagePath { get; set; }
        
        public bool isCold { get; set; }

        public bool isHot { get; set; }

        public bool isSweet { get; set; }

        public bool isVegitarian { get; set; }

        public int Likes { get; set; }
    }
}
