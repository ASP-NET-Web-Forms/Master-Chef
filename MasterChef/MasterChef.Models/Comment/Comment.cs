namespace MasterChef.Models.Comment
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using AppUser;
    using Article;
    using Common.Constants;

    public class Comment
    {
        public int ID { get; set; }

        [Required]
        [MinLength(ModelConstants.CommentContentMinLength)]
        [MaxLength(ModelConstants.CommentContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        
        public string CreatorID { get; set; }
        
        public virtual AppUser Creator { get; set; }
        
        public int ArticleID { get; set; }

        public virtual Article Article { get; set; }
    }
}
