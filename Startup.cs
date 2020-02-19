using Ecommerce.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ecommerce.Startup))]
namespace Ecommerce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createUsers();
        }

        private async void createUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var AdminEmail = await userManager.FindByEmailAsync("123@a.com");
            var CustomerEmail = await userManager.FindByEmailAsync("123@c.com");

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Customer"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }

            

            if (AdminEmail == null)
            {
                var user = new ApplicationUser();
                user.UserName = "123@a.com";
                user.Email = "123@a.com";
                string userPWD = "Password1@";

                var chkUser = userManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            if (CustomerEmail == null)
            {
                var user = new ApplicationUser();
                user.UserName = "123@c.com";
                user.Email = "123@c.com";
                string userPWD = "Password1@";

                var chkUser = userManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                }
            }
        }
    }
}
