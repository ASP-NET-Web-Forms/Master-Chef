namespace MasterChef.Web.Models
{
    public class HomeNewestArticlesViewModel
    {
        public int ID { get; set; }
        
        public string Title { get; set; }
        
        public string ImagePath { get; set; }

        public int Comments { get; set; }

        public int Likes { get; set; }
    }
}
