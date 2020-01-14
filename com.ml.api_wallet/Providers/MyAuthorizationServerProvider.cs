using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Owin.Security.OAuth;
using com.ml.api_wallet.Services;

namespace com.ml.api_wallet.Providers
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        #region[ValidateClientAuthentication]
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
                context.Validated();

            return Task.FromResult<object>(null);
        }
        #endregion

        #region[TokenEndpoint]
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
        #endregion

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            return Task.Factory.StartNew(() =>
            {
                var userName = context.UserName;
                var password = context.Password;
                var walletService = new WalletService(); // our created one
                var wallet = walletService.ValidateUser(userName, password);
                if (wallet != null)
                {
                    var claims = new List<Claim>()
                    {
                        //new Claim(ClaimTypes.Sid, Convert.ToString(wallet.Id)),
                        //new Claim(ClaimTypes.Name, wallet.FName+" "+wallet.LName),
                        //new Claim(ClaimTypes.Role, "Admin"),
                        //new Claim(ClaimTypes.Email, wallet.Email),
                        //new Claim("Id",  Convert.ToString(wallet.Id)),
                        //new Claim("Username",  wallet.Username)
                    };

                    ClaimsIdentity oAuthIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);

                    var properties = CreateProperties(wallet.name);
                    var ticket = new AuthenticationTicket(oAuthIdentity, properties);
                    context.Validated(ticket);
                }
                else
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect");
                    context.Response.Headers.Add("AuthorizationResponse", new[] { "Failed" });
                }
            });
        }

        #region[CreateProperties]
        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
        #endregion
    }
}