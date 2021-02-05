using Blogging.App_Start;
using Blogging.Areas.OAuth2;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using Unity.AspNet.WebApi;

namespace Blogging
{
    public partial class Startup
    {
        #region Public /Protected Properties.  

        /// <summary>  
        /// OAUTH options property  
        /// </summary>  
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        /// <summary>  
        /// Public client ID property  
        /// </summary>  
        public static string PublicClientId { get; private set; }

        #endregion

        public void ConfigureAuth(IAppBuilder app)
        {

            // Configure the application for OAuth based flow  
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new AppOAuthProvider(PublicClientId),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(15),
                AllowInsecureHttp = true // this is just for development purpose 
            };

            // Enable the application to use bearer tokens to authenticate users  
            app.UseOAuthBearerTokens(OAuthOptions);

        }
    }
}