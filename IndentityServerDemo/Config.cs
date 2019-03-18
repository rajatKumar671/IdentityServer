using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IndentityServerDemo
{
    public class Config
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
    {
        // other clients omitted...

        // OpenID Connect implicit flow client (MVC)
        new Client
        {
            ClientId = "mvc",
            ClientName = "MVC Client",
            AllowedGrantTypes = GrantTypes.Implicit,
            RequireConsent=false,

            // where to redirect to after login
            RedirectUris = { "http://localhost:51893/signin-oidc" },
            
            // where to redirect to after logout
            PostLogoutRedirectUris = { "http://localhost:51893/signout-callback-oidc" },

            AllowedScopes = new List<string>
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
            },
            AllowAccessTokensViaBrowser=true,
        }
    };
        }

        public static IEnumerable<IdentityResource> IdentityResources = new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

        public static List<TestUser> GetUsers = new List<TestUser>
    {
        new TestUser
        {
            SubjectId = "1",
            Username = "alice",
            Password = "password",

            Claims = new []
            {
                new Claim("name", "Alice"),
                new Claim("website", "https://alice.com")
            }
        },
        new TestUser
        {
            SubjectId = "2",
            Username = "bob",
            Password = "password",

            Claims = new []
            {
                new Claim("name", "Bob"),
                new Claim("website", "https://bob.com")
            }
        }
    };
    }
}

