using System.Data.Entity;
using System.Web.Security;

namespace commenergy.Migrations
{
    public class DataContextInitializer:DropCreateDatabaseAlways<commenergy.Models.commenergyContext>
    {
        protected override void Seed(commenergy.Models.commenergyContext context)
        {
            WebSecurity.Register("Demo", "123456", "demo@demo.com", true, "Demo", "Demo");
            Roles.CreateRole("Admin");
            Roles.AddUserToRole("Demo", "Admin");
        }
    }
}