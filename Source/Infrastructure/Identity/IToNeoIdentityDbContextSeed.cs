using IToNeo.ApplicationCore.Constants;
using IToNeo.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace IToNeo.Infrastructure.Identity
{
    public class IToNeoIdentityDbContextSeed
    {
        private static string _adminNameAndEmail = "admin@microsoft.com";
        private static string _operatorNameAndEmail = "operator@microsoft.com";
        private static string _userNameAndEmail = "user@microsoft.com";
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            await roleManager.CreateAsync(new ApplicationRole(UserRoleConstants.ADMINISTATOR));
            await roleManager.CreateAsync(new ApplicationRole(UserRoleConstants.OPERATOR));
            await roleManager.CreateAsync(new ApplicationRole(UserRoleConstants.USER));

            var adminAppUser = new ApplicationUser { UserName = _adminNameAndEmail, Email = _adminNameAndEmail };
            await userManager.CreateAsync(adminAppUser, AuthorizationConstants.DEFAULT_PASSWORD);

            var operatorAppUser = new ApplicationUser { UserName = _operatorNameAndEmail, Email = _operatorNameAndEmail };
            await userManager.CreateAsync(operatorAppUser, AuthorizationConstants.DEFAULT_PASSWORD);

            var userApp = new ApplicationUser { UserName = _userNameAndEmail, Email = _userNameAndEmail };
            await userManager.CreateAsync(userApp, AuthorizationConstants.DEFAULT_PASSWORD);

            var adminUser = await userManager.FindByNameAsync(_adminNameAndEmail);
            await userManager.AddToRoleAsync(adminUser, UserRoleConstants.ADMINISTATOR);
            var adminConfirmToken = await userManager.GenerateEmailConfirmationTokenAsync(adminUser);
            await userManager.ConfirmEmailAsync(adminUser, adminConfirmToken);

            var operatorUser = await userManager.FindByNameAsync(_operatorNameAndEmail);
            await userManager.AddToRoleAsync(operatorUser, UserRoleConstants.OPERATOR);
            var operatorConfirmToken = await userManager.GenerateEmailConfirmationTokenAsync(operatorUser);
            await userManager.ConfirmEmailAsync(operatorUser, operatorConfirmToken);

            var user = await userManager.FindByNameAsync(_userNameAndEmail);
            await userManager.AddToRoleAsync(user, UserRoleConstants.USER);
            var userConfirmToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
            await userManager.ConfirmEmailAsync(user, userConfirmToken);
        }
    }
}
