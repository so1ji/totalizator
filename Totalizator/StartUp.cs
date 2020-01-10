using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using Totalizator.Providers;

[assembly: OwinStartup(typeof(Totalizator.Startup))]
namespace Totalizator
{
    public class Startup
    {

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new OAuthCustomTokenProvider(), 
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(20),
                AllowInsecureHttp = true,
                RefreshTokenProvider = new OAuthCustomRefreshTokenProvider()
            };

            app.UseOAuthAuthorizationServer(OAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}