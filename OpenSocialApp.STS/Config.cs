// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ids4.simple
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Phone(),
                new IdentityResources.Address()
            };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[] {
            new ApiScope("api1", "My API")
         };

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[] {
            new ApiResource("api1", "My API", new string[] { JwtClaimTypes.GivenName, JwtClaimTypes.FamilyName, JwtClaimTypes.Email })
        };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                },
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    // where to redirect to after login
                    RedirectUris = { "https://localhost:5002/signin-oidc" },
                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    }
                },
                new Client {
                    ClientId = "angular_spa",
                    ClientName = "Angular 4 Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = new List<string> { "openid", "profile", "api1", "email" },
                    // The Angular app runs on localhost:80 (ngnix) with / route
                    RedirectUris = new List<string> { "http://localhost:80/auth/auth-callback?id=1234" },
                    PostLogoutRedirectUris = new List<string> { "http://localhost:80/" },
                    AllowedCorsOrigins = new List<string> { "http://localhost:80" },
                    AllowAccessTokensViaBrowser = true
                },
                new Client
                {
                    ClientId="pkce_client",
                    ClientSecrets={new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.Code,
                    RedirectUris={"https://localhost:5002/signin-oidc"},
                    PostLogoutRedirectUris={"https://localhost:5002/signout-callback-oidc"},
                    AllowedScopes=new List<string>
                    {
                        "openid",
                        "profile",
                        "api1"
                    }
                }
             };

        public static List<TestUser> Users => new List<TestUser> {
            new TestUser
            {
                Username = "roger",
                Claims = new Claim[] {
                    new Claim(JwtClaimTypes.Name, "Roger D"),
                    new Claim(JwtClaimTypes.GivenName, "roger"),
                    new Claim(JwtClaimTypes.FamilyName, "D Gol"),
                    new Claim(JwtClaimTypes.WebSite, "http://roger.com"),
                    new Claim(JwtClaimTypes.Email, "roger@op.com")
                },
                Password = "Abcd@1234",
                IsActive = true,
                SubjectId = Guid.NewGuid().ToString(),
            },
            new TestUser
            {
                Username = "garp",
                Claims = new Claim[] {
                    new Claim(JwtClaimTypes.Name, "Garp D Fist"),
                    new Claim(JwtClaimTypes.GivenName, "garp"),
                    new Claim(JwtClaimTypes.FamilyName, "D Fist"),
                    new Claim(JwtClaimTypes.WebSite, "http://garp.com"),
                    new Claim(JwtClaimTypes.Email, "garp@op.com")
                },
                Password = "Abcd@1234",
                IsActive = true,
                SubjectId = Guid.NewGuid().ToString(),
            },
            new TestUser
            {
                Username = "Lucy",
                Claims = new Claim[] {
                    new Claim(JwtClaimTypes.Name, "Lucy D"),
                    new Claim(JwtClaimTypes.GivenName, "lucy"),
                    new Claim(JwtClaimTypes.FamilyName, "D Key"),
                    new Claim(JwtClaimTypes.WebSite, "http://lucy.com"),
                    new Claim(JwtClaimTypes.Email, "lucy@op.com")
                },
                Password = "Abcd@1234",
                IsActive = true,
                SubjectId = Guid.NewGuid().ToString(),
            },
            new TestUser
            {
                Username = "ace",
                Claims = new Claim[] {
                    new Claim(JwtClaimTypes.Name, "Ace D"),
                    new Claim(JwtClaimTypes.GivenName, "ace"),
                    new Claim(JwtClaimTypes.FamilyName, "D Gas"),
                    new Claim(JwtClaimTypes.WebSite, "http://ace.com"),
                    new Claim(JwtClaimTypes.Email, "ace@op.com")
                },
                Password = "Abcd@1234",
                IsActive = true,
                SubjectId = Guid.NewGuid().ToString(),
            },
            new TestUser
            {
                Username = "Dragon",
                Claims = new Claim[] {
                    new Claim(JwtClaimTypes.Name, "Dragon"),
                    new Claim(JwtClaimTypes.GivenName, "dragon"),
                    new Claim(JwtClaimTypes.FamilyName, "D Key"),
                    new Claim(JwtClaimTypes.WebSite, "http://dragon.com"),
                    new Claim(JwtClaimTypes.Email, "dragon@op.com")
                },
                Password = "Abcd@1234",
                IsActive = true,
                SubjectId = Guid.NewGuid().ToString(),
            }
        };
    }
}