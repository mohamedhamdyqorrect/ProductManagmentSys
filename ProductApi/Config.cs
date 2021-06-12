using IdentityModel.AspNetCore.OAuth2Introspection;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi
{
    public class Config
    {


        static Func<HttpRequest, string> AuthHeaderTokenRetriever { get; set; }
        static Func<HttpRequest, string> QueryStringTokenRetriever { get; set; }

        static Config()
        {
            AuthHeaderTokenRetriever = TokenRetrieval.FromAuthorizationHeader();
            QueryStringTokenRetriever = TokenRetrieval.FromQueryString();
        }

        public static string FromHeaderAndQueryString(HttpRequest request)
        {
            var token = AuthHeaderTokenRetriever(request);

            if (string.IsNullOrEmpty(token) && (request.Path.Value.EndsWith("Hub")))
            {
                token = QueryStringTokenRetriever(request);
            }
            return token;
        }
    }
}
