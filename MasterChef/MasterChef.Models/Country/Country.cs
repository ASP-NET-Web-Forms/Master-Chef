namespace MasterChef.Models.Country
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AppUser;
    using Common.Constants;

    public class Country
    {
        private ICollection<AppUser> users;

        public Country()
        {
            this.users = new HashSet<AppUser>();
        }

        public int ID { get; set; }

        [Required]
        [MinLength(ModelConstants.CountryNameMinLength)]
        [MaxLength(ModelConstants.CountryNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<AppUser> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
