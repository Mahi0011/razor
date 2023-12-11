//using Microsoft.AspNetCore.Authentication;
//using Microsoft.Extensions.Options;
//using Swashbuckle.AspNetCore.SwaggerGen;
//using System.Net.Http.Headers;
//using System.Security.Claims;
//using System.Text;
//using System.Text.Encodings.Web;

//namespace RAZOR_Chat.Service
//{
//    public class AuthenticationService : AuthenticationHandler<AuthenticationSchemeOptions>
//    {
//        public AuthenticationService(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
//        {
//        }

//        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
//        {
//            if (!Request.Headers.ContainsKey("Authorization"))
//            {
//                return  AuthenticateResult.Fail("NO header found");
//            }
//            var headervalue = AuthenticationHeaderValue.Parse("Authorization");
//            if (headervalue == null)
//            {
//                var bytes = Convert.FromBase64String(headervalue.Parameter);
//                string credentials = Encoding.UTF8.GetString(bytes);
//                string[] array = credentials.Split(":");
//                string token = array[0];
//                if (token != null)
//                {
//                    var claims = new[] { new Claim(ClaimTypes.Name, token) };
//                    var identity = new ClaimsIdentity(claims, token);
//                    var principle = new ClaimsPrincipal(identity);
//                    var ticket = new AuthenticationTicket(principle, token);
//                    return AuthenticateResult.Success(ticket);
//                }
//                else
//                {
//                    return AuthenticateResult.Fail("failed");
//                }
//            }
//            else
//            {
//                return AuthenticateResult.Fail("failed");
//            }
//        }
//    }
//}
