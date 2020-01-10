﻿using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Totalizator.Models;
using Totalizator.Services;

namespace Totalizator.Providers
{
    public class OAuthCustomTokenProvider : OAuthAuthorizationServerProvider
    {

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var email = context.UserName;
                var password = context.Password;
                var userService = new UserService();
                var user = userService.Validate(email, password);
                if (user != null)
                {
                    var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Sid, Convert.ToString(user.Id)),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                };
                    foreach (var role in user.Roles)
                        claims.Add(new Claim(ClaimTypes.Role, role.Name.ToString()));

                    var data = new Dictionary<string, string>
                {
                    { "userName", user.UserName },
                    { "roles", string.Join(",", user.Roles)}
                };
                    var properties = new AuthenticationProperties(data);

                    ClaimsIdentity oAuthIdentity = new ClaimsIdentity(claims,
                        Startup.OAuthOptions.AuthenticationType);

                    var ticket = new AuthenticationTicket(oAuthIdentity, properties);
                    context.Validated(ticket);
                }
                else
                {
                    context.SetError("invalid_grant", "Either email or password is incorrect");
                }

            });
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
                context.Validated();

            return Task.FromResult<object>(null);
        }


        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }

    }
}