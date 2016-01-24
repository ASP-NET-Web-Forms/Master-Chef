namespace MasterChef.Models.Article
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using AppUser;

    public class ArticleLike
    {
        public int ID { get; set; }
        
        public string AppUserID { get; set; }

        public virtual AppUser AppUser { get; set; }
        
        public int ArticleID { get; set; }

        public virtual Article Article { get; set; }
    }
}
