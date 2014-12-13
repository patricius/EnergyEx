using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using commenergy.Models.Models;

namespace commenergy.App_Start
{


    public partial class Startup
    {


        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void Configuration(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            app.UseGoogleAuthentication(
  clientId: "000-000.apps.googleusercontent.com",
  clientSecret: "00000000000");

            //AddUserAndRoles();
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
                UserName = "Inst",
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