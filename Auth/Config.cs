// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace Auth
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("api1", "My API"),
                new ApiScope("scope1"),
                new ApiScope("scope2"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
{
    ClientName = "angular_code_client",
    ClientId = "angularFrontProcutClient",
    AccessTokenType = AccessTokenType.Reference,
    // RequireConsent = false,
    AccessTokenLifetime = 330,// 330 seconds, default 60 minutes
    IdentityTokenLifetime = 30,

    RequireClientSecret = false,
    AllowedGrantTypes = GrantTypes.Code,
    RequirePkce = true,

    AllowAccessTokensViaBrowser = true,
    RedirectUris = new List<string>
    {
        "http://localhost:4200",
        "http://localhost:4200/silent-renew.html"

    },
    PostLogoutRedirectUris = new List<string>
    {
        "http://localhost:4200/unauthorized",
        "http://localhost:4200"
    },
    AllowedCorsOrigins = new List<string>
    {
        "http://localhost:4200"
    },
    AllowedScopes = new List<string>
    {
        "openid","scope1"
        //"dataEventRecords",
        //"dataeventrecordsscope",
        //"securedFiles",
        //"securedfilesscope",
        //"role",
        //"profile",
        //"email"
    }
},
                new Client
{
    ClientId = "product_api",
    ClientName = "product_api (Code with PKCE)",

    RedirectUris = { "http://localhost:19663/" },
    PostLogoutRedirectUris = { "http://localhost:19663/" },

    RequireClientSecret = false,

    AllowedGrantTypes = GrantTypes.Code,
    RequirePkce = true,
     // scopes that client has access to
            AllowedScopes = { "api1" },
    AllowOfflineAccess = true,
    RefreshTokenUsage = TokenUsage.ReUse
 },
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "scope1" }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:44300/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "scope2" }
                },
            };
    }
}