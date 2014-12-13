using commenergy.Models.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace commenergy.Models.appContextMigrations
{
  

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"appContextMigrations";
   
        }
 
        protected override void Seed(ApplicationDbContext context)
        {
            context.Configuration.LazyLoadingEnabled = true;
            context.Configuration.ProxyCreationEnabled = false;
            this.AddUserAndRoles();
        }
  
  
        bool AddUserAndRoles()
        {
            bool success = false;
  
            var idManager = new IdentityManager();
            success = idManager.CreateRole("Admin");
            if (!success == true) return success;
  
            success = idManager.CreateRole("CanEdit");
            if (!success == true) return success;
  
            success = idManager.CreateRole("User");
            if (!success) return success;
  
  
            var newUser = new ApplicationUser()
            {
                UserName = "onst",
                FirstName = "Onst",
                LastName = "Wang",
                Email = "poobear@dogs.com"
            };
  
            // Be careful here - you  will need to use a password which will 
            // be valid under the password rules for the application, 
            // or the process will abort:
            success = idManager.CreateUser(newUser, "Password8");
            if (!success) return success;
  
            success = idManager.AddUserToRole(newUser.Id, "Admin");
            if (!success) return success;
  
            success = idManager.AddUserToRole(newUser.Id, "CanEdit");
            if (!success) return success;
  
            success = idManager.AddUserToRole(newUser.Id, "User");
            if (!success) return success;
  
            return success;
        }
    }
}
     