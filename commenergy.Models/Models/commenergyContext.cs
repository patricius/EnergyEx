using System.Data.Entity;
using System.Linq;
using commenergy.Models.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using commenergy.Models.appContextMigrations;

namespace commenergy.Models
{
    public class commenergyContext : DbContext
    {

      
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the followingz
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<commenergy.Models.commenergyContext>());

        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }

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

    }
}