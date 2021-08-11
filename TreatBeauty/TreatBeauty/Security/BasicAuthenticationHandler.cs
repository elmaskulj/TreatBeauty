using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using TreatBeauty.Interfaces;

namespace TreatBeauty.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IBaseUserService _service;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IBaseUserService _service) : base(options, logger, encoder, clock)
        {
            this._service = _service;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
       {
           
                if (!Request.Headers.ContainsKey("Authorization"))
                {
                    return AuthenticateResult.Fail("Missing authorization header");
                }
            
            
            Model.BaseUser user = null;

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                var username = credentials[0];
                var password = credentials[1];

                user = await _service.Login(username, password);

            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail("Incorrect username or password");
            }

            if (user == null)
                return AuthenticateResult.Fail("Invalid Username or Password");

            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName),
            };

            foreach (var role in user.BaseUserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
            }

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);

        }
    }
}
