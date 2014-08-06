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
        this.Configuration.LazyLoadingEnabled = true; 

    }



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
       