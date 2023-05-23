using AppleShop.Identity.API.Consts;
using AppleShop.Identity.API.Infrastructure;
using AppleShop.Identity.API.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AppleShop.Identity.API.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Initialize()
        {
            var isAdminRoleExist = (await _roleManager.FindByNameAsync(RoleConst.Admin)) != null;
            if (isAdminRoleExist)
                return;

            await CreateDefaultRoles();
            await CreateDefaultAdmin();
            await CreateDefaultCustomer();
        }

        private async Task CreateDefaultRoles()
        {
            await _roleManager.CreateAsync(new IdentityRole(RoleConst.Admin));
            await _roleManager.CreateAsync(new IdentityRole(RoleConst.Customer));
        }

        private async Task CreateDefaultAdmin()
        {
            var adminUser = new ApplicationUser()
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "111111111111",
                FirstName = "Test",
                LastName = "Admin",
            };

            await _userManager.CreateAsync(adminUser, "<YourStrong@Passw0rd>");
            await _userManager.AddToRoleAsync(adminUser, RoleConst.Admin);

            await _userManager.AddClaimsAsync(adminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{adminUser.FirstName} {adminUser.LastName}"),
                new Claim(JwtClaimTypes.GivenName, adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, adminUser.LastName),
                new Claim(JwtClaimTypes.Role, RoleConst.Admin),
            });
        }

        private async Task CreateDefaultCustomer()
        {
            var customerUser = new ApplicationUser()
            {
                UserName = "customer@gmail.com",
                Email = "customer@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "111111111111",
                FirstName = "Test",
                LastName = "Customer",
            };

            await _userManager.CreateAsync(customerUser, "<YourStrong@Passw0rd>");
            await _userManager.AddToRoleAsync(customerUser, RoleConst.Customer);

            await _userManager.AddClaimsAsync(customerUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{customerUser.FirstName} {customerUser.LastName}"),
                new Claim(JwtClaimTypes.GivenName, customerUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, customerUser.LastName),
                new Claim(JwtClaimTypes.Role, RoleConst.Customer),
            });
        }
    }
}
