using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebPages.OAuth;

namespace commenergy.App_Start
{
    public static class OAuthProviders
    {
        public static void Configure()
        {
            Microsoft.Web.WebPages.OAuth.OAuthWebSecurity.RegisterGoogleClient();
        }

    }
}