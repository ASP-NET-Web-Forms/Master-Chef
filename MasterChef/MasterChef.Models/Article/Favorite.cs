namespace MasterChef.Models.Article
{
    using AppUser;

    public class Favorite
    {
        public int ID { get; set; }

        public string UserID { get; set; }

        public virtual AppUser User { get; set; }

        public int ArticleID { get; set; }

        public virtual Article Article { get; set; }
    }
}