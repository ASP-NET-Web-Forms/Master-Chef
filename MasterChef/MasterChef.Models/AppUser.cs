namespace MasterChef.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            this.Comments = new HashSet<Comment>();
            this.CreatedArticles = new HashSet<Article>();
            this.FavoriteArticles = new HashSet<Article>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CountryID { get; set; }

        public virtual Country Country { get; set; }

        public int ImageID { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Article> CreatedArticles { get; set; }

        public virtual ICollection<Article> FavoriteArticles { get; set; }

        public ClaimsIdentity GenerateUserIdentity(UserManager<AppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
