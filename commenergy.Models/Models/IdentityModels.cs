using commenergy.Models.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commenergy.Models.Models
{
        public class ApplicationUser : IdentityUser
        {
            [Required]
            public string FirstName { get; set; }

            [Required]
            public string LastName { get; set; }

           
            public string Email { get; set; }
        
  
        [Key]
        public override string Id { get; set; }
           
        public string UserId { get; set; }
            public virtual ICollection<Article> Articles { get; set; }

        public virtual String Password { get; set; }

        [DataType(DataType.MultilineText)]
        public virtual String Comment { get; set; }

        public virtual Boolean IsApproved { get; set; }
        public virtual int PasswordFailuresSinceLastSuccess { get; set; }
        public virtual DateTime? LastPasswordFailureDate { get; set; }
        public virtual DateTime? LastActivityDate { get; set; }
        public virtual DateTime? LastLockoutDate { get; set; }
        public virtual DateTime? LastLoginDate { get; set; }
        public virtual String ConfirmationToken { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        public virtual Boolean IsLockedOut { get; set; }
        public virtual DateTime? LastPasswordChangedDate { get; set; }
        public virtual String PasswordVerificationToken { get; set; }
        public virtual DateTime? PasswordVerificationTokenExpirationDate { get; set; }

        
    }
}


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("myConnectionString")
        {


        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>()
               .ToTable("AspNetUsers");
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("AspNetUsers");
            modelBuilder.Entity<IdentityUserClaim>()
               .ToTable("AspNetUserClaims");
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId).ToTable("dbo.AspNetUserLogins");
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(f => f.LoginProvider).ToTable("dbo.AspNetUserLogins");
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(h => h.ProviderKey).ToTable("dbo.AspNetUserLogins");
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id).ToTable("dbo.AspNetRoles");
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId }).ToTable("dbo.AspNetUserRoles");
        }


        public class IdentityManager
        {
            public bool RoleExists(string name)
            {
                var rm = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(new ApplicationDbContext()));
                return rm.RoleExists(name);
            }


            public bool CreateRole(string name)
            {
                var rm = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(new ApplicationDbContext()));
                var idResult = rm.Create(new IdentityRole(name));
                return idResult.Succeeded;
            }


            public bool CreateUser(ApplicationUser user, string password)
            {
                var um = new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var idResult = um.Create(user, password);
                return idResult.Succeeded;
            }


            public bool AddUserToRole(string userId, string roleName)
            {
                var um = new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var idResult = um.AddToRole(userId, roleName);
                return idResult.Succeeded;
            }


            public void ClearUserRoles(string userId)
            {
                var um = new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var user = um.FindById(userId);
                var currentRoles = new List<IdentityUserRole>();
                currentRoles.AddRange(user.Roles);
                foreach (var role in currentRoles)
                {
                    um.RemoveFromRole(userId, role.Role.Name);
                }
            }
        }
    }

