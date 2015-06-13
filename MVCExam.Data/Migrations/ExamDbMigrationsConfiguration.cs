using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MVCExam.Models;
using MVCExam.Web;

namespace MVCExam.Data.Migrations
{
    class ExamDbMigrationsConfiguration : DbMigrationsConfiguration<ExamDbContext>
    {
        public ExamDbMigrationsConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(ExamDbContext context)
        {
            base.Seed(context);
            if (!context.Roles.Any())
            {
                CreateUserRoles(context);
            }
            if (!context.Users.Any())
            {
                CreateUsers(context);
            }
            context.SaveChanges();
        }

        public void CreateUsers(ExamDbContext context)
        {
            
            UserStore<User> userStore = new UserStore<User>(context);
            ApplicationUserManager userManager = new ApplicationUserManager(userStore);

                var users = new List<User>()
                {
                    new User()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "Goshov@abv.bg",
                        UserName = "Goshko_pi4a"
                        
                    },
                    new User()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "Gi4ka@gbg.bg",
                        UserName = "Ginka",
                        
                    },
                    new User()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "penka@softuni.bg",
                        UserName = "penarkova",
                        
                    }

                };
                var admins = new List<User>()
                {
                    new User()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = "admin@abv.bg",
                        UserName = "admin"
                        
                    }

                };

                foreach (var user in users)
                {
                    context.Users.Add(user);
                    var result = userManager.Create(user,"123123");
                    context.SaveChanges();
                    userManager.AddToRole(user.Id, "User");
                }

                foreach (var user in admins)
                {
                    var result = userManager.Create(user, "123123");
                    context.SaveChanges();
                    userManager.AddToRole(user.Id, "Administrator");
                    
                }
            
        }
        private void CreateUserRoles(ExamDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (!context.Roles.Any())
            {
                var adminRole = new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Administrator"};
                var userRole = new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "User" };

                context.Roles.Add(adminRole);
                context.Roles.Add(userRole);

                context.SaveChanges();
            }
        }
    }
}
