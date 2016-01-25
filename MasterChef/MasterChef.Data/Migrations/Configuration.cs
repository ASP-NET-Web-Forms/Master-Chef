namespace MasterChef.Data.Migrations
{
    using FakeData;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MasterChefDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MasterChefDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            //Roles
            var roles = Settings.Default.Roles.Split(',');
            var adminRole = roles[0];
            var userRole = roles[1];
            foreach (var role in roles)
            {
                roleManager.Create(new IdentityRole { Name = role });
            }

            var userStore = new UserStore<AppUser>(context);
            var userManager = new UserManager<AppUser>(userStore);

            // Images
            var defaultImage = new Image { Path = "~/Uploaded_Files/default.png" };
            var adminImage = new Image { Path = "~/Uploaded_Files/admin.jpg" };
            context.Images.AddOrUpdate(
                defaultImage,
                adminImage
            );

            context.SaveChanges();

            // Countries
            var json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\App_Data\countries.json");
            var countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(json);

            foreach (var country in countries)
            {
                context.Countries.Add(country);
            }

            //// Users
            //var countryBulgaria = context.Countries.Local.Single(item => item.Name == "Bulgaria");
            //var userAdmin = new AppUser
            //{
            //    UserName = "admin@admin",
            //    Email = "admin@admin",
            //    FirstName = NameData.GetFirstName(),
            //    LastName = NameData.GetSurname(),
            //    Country = countryBulgaria,
            //    Image = adminImage
            //};
            //userManager.Create(userAdmin, userAdmin.UserName);
            //userManager.AddToRole(userAdmin.Id, adminRole);

            //for (int userIndex = 0; userIndex < 100; userIndex++)
            //{
            //    bool isSuccess = false;

            //    while (!isSuccess)
            //    {
            //        var firstName = NameData.GetFirstName();
            //        var lastName = NameData.GetSurname();
            //        var userName = firstName + "@" + lastName;

            //        Country country = null;
            //        while (country == null)
            //        {
            //            var countryName = PlaceData.GetCountry();
            //            country = context.Countries.Local.SingleOrDefault(item => item.Name == countryName);
            //        }

            //        var user = new AppUser
            //        {
            //            UserName = userName,
            //            Email = userName,
            //            FirstName = firstName,
            //            LastName = lastName,
            //            Country = country,
            //            Image = new Image() { Path = string.Format("~/Uploaded_Files/Users/{0}.jpg", userIndex + 1) }
            //        };
            //        isSuccess = userManager.Create(user, userName).Succeeded;
            //        if (isSuccess)
            //        {
            //            userManager.AddToRole(user.Id, userRole);
            //        }
            //    }
            //}

            context.SaveChanges();
        }
    }
}
