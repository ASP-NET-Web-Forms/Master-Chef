namespace MasterChef.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Article
    {
        public Article()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int ID { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public int Likes { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey("Creator")]
        public string CreatorID { get; set; }

        public virtual AppUser Creator { get; set; }

        public int ImageID { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }       
    }
}
