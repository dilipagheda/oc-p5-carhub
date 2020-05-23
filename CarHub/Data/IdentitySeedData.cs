using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CarHub.Data
{
    public static class IdentitySeedData
    {
        private const string AdminUser = "Admin@carhub.com";
        private const string AdminPassword = "P@ssword123";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.CreateScope())
            {
                var userManager = (UserManager<IdentityUser>)scope.ServiceProvider
                    .GetService(typeof(UserManager<IdentityUser>));

                IdentityUser user = await userManager.FindByIdAsync(AdminUser);

                if(user == null)
                {
                    user = new IdentityUser(AdminUser);
                    await userManager.CreateAsync(user, AdminPassword);
                }
            }
        }
    }
}
