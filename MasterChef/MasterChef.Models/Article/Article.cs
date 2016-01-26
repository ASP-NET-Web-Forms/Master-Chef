namespace MasterChef.Models.Article
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Comment;
    using AppUser;
    using Image;
    using Common.Constants;

    public class Article
    {
        private ICollection<Comment> comments;
        private ICollection<ArticleLike> likes;
        private ICollection<Favorite> favoriteUsers;

        public Article()
        {
            this.comments = new HashSet<Comment>();
            this.likes = new HashSet<ArticleLike>();
            this.favoriteUsers = new HashSet<Favorite>();
        }

        public int ID { get; set; }

        [Required]
        [MinLength(ModelConstants.ArticleContentMinLength)]
        public string Content { get; set; }

        [Required]
        [MinLength(ModelConstants.ArticleTitleMinLength)]
        [MaxLength(ModelConstants.ArticleTitleMaxLength)]
        public string Title { get; set; }
        
        [Required]
        public DateTime CreatedOn { get; set; }

        public string CreatorID { get; set; }
        
        public virtual AppUser Creator { get; set; }

        public int ImageID { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<Favorite> FavoriteUsers
        {
            get { return this.favoriteUsers; }
            set { this.favoriteUsers = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<ArticleLike> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }
    }
}
