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
            base.OnModelCreating(modelBuilder);
            this.Configuration.LazyLoadingEnabled = true;
            var user = modelBuilder.Entity<IdentityUser>().HasKey(u => u.Id).ToTable("dbo.AspNetUsers"); //Specify our our own table names instead of the defaults

            user.Property(iu => iu.Id).HasColumnName("Id");
            user.Property(iu => iu.UserName).HasColumnName("UserName");
            
            
            user.Property(iu => iu.PasswordHash).HasColumnName("PasswordHash");
            user.Property(iu => iu.SecurityStamp).HasColumnName("SecurityStamp");

            user.HasMany(u => u.Roles).WithRequired().HasForeignKey(ur => ur.UserId);
            user.HasMany(u => u.Claims).WithRequired().HasForeignKey(uc => uc.UserId);
            user.HasMany(u => u.Logins).WithRequired().HasForeignKey(ul => ul.UserId);
            user.Property(u => u.UserName).IsRequired();

            var applicationUser = modelBuilder.Entity<ApplicationUser>().HasKey(au => au.Id).ToTable("dbo.AspNetUsers"); //Specify our our own table names instead of the defaults

            applicationUser.Property(au => au.Id).HasColumnName("Id");
           
            applicationUser.Property(au => au.UserName).HasMaxLength(50).HasColumnName("UserName");
            applicationUser.Property(au => au.PasswordHash).HasColumnName("PasswordHash");
            applicationUser.Property(au => au.SecurityStamp).HasColumnName("SecurityStamp");
           
            applicationUser.Property(au => au.Email).HasColumnName("EmailAddress").HasMaxLength(254).IsRequired();
       

            var role = modelBuilder.Entity<IdentityRole>().HasKey(ir => ir.Id).ToTable("dbo.AspNetRoles");

            role.Property(ir => ir.Id).HasColumnName("Id");
            role.Property(ir => ir.Name).HasColumnName("Name");

            var claim = modelBuilder.Entity<IdentityUserClaim>().HasKey(iuc => iuc.Id).ToTable("AspNetUserClaims");

            claim.Property(iuc => iuc.Id).HasColumnName("Id");
            claim.Property(iuc => iuc.ClaimType).HasColumnName("ClaimType");
            claim.Property(iuc => iuc.ClaimValue).HasColumnName("ClaimValue");
            claim.Property(iuc => iuc.UserId).HasColumnName("UserId");

            var login = modelBuilder.Entity<IdentityUserLogin>().HasKey(iul => new { iul.UserId, iul.LoginProvider, iul.ProviderKey }).ToTable("dbo.AspNetUserLogins"); //Used for third party OAuth providers

            login.Property(iul => iul.UserId).HasColumnName("UserId");
            login.Property(iul => iul.LoginProvider).HasColumnName("LoginProvider");
            login.Property(iul => iul.ProviderKey).HasColumnName("ProviderKey");

            var userRole = modelBuilder.Entity<IdentityUserRole>().HasKey(iur => new { iur.UserId, iur.RoleId }).ToTable(
                "dbo.AspNetUserRoles");
          
            userRole.Property(ur => ur.UserId).HasColumnName("UserId");
            userRole.Property(ur => ur.RoleId).HasColumnName("RoleId");
           
        }

    }
}