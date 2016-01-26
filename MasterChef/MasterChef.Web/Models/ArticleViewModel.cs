namespace MasterChef.Web.Models
{
    using System;

    public class ArticleViewModel
    {
        public int ID { get; set; }

        public string Content { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatorID { get; set; }

        public string Creator { get; set; }

        public string ImagePath { get; set; }

        public int Comments { get; set; }

        public int Likes { get; set; }
    }
}