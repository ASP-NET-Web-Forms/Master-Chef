namespace MasterChef.Web.Models
{
    using System;

    public class CommentViewModel
    {
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatorID { get; set; }

        public string Creator { get; set; }
    }
}