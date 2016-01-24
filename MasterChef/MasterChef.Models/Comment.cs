namespace MasterChef.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Comment
    {
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey("Creator")]
        public string CreatorID { get; set; }

        public virtual AppUser Creator { get; set; }

        [Required]
        public int ArticleID { get; set; }

        public virtual Article Article { get; set; }
    }
}
