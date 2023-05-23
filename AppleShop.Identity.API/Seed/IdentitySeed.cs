using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace AppleShop.Identity.API.Seed
{
    public static class IdentitySeed
    {
        public static IEnumerable<IdentityResource> IdentityResources
            => new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScope
            => new List<ApiScope>()
            {
                new ApiScope("Mango", "Mango Server"),
                new ApiScope(name: "read", displayName: "Read your data."),
                new ApiScope(name: "write", displayName: "Write your data."),
                new ApiScope(name: "delete", displayName: "Delete your data."),
            };

        public static IEnumerable<Client> Clients
            => new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret") },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "read", "write", "profile" }
                },
                new Client
                {
                    ClientId = "mango",
                    ClientSecrets = { new Secret("secret") },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:7010/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:7010/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "mango"
                    }
                }
            };
    }
}
