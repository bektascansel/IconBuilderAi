using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth;
using MediatR;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.ChangePassword;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Login;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Password.ForgotPassword;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Password.ResetPassword;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Register;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.VerifyEmail;
using MextFullstackSaaS.Domain.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using static System.Net.WebRequestMethods;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.SocialLogin;

namespace MextFullstackSaaS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAuthController : ControllerBase
    {

        private readonly ISender? _mediatr;
        private readonly GoogleSettings _googleSettings;
        private const string REDIRECT_URI = "https://localhost:7169/api/UsersAuth/signin-google";
        private readonly string _googleAuthorizationUrl;


        public UsersAuthController(ISender? mediatr,IOptions<GoogleSettings> googleSettings)
        {
            _mediatr = mediatr;
            _googleSettings = googleSettings.Value;
            _googleAuthorizationUrl = $"https://accounts.google.com/o/oauth2/v2/auth?" +
                                         $"client_id={_googleSettings.ClientId}&" +
                                         $"response_type=code&" +
                                         $"scope=openid%20email%20profile&" +
                                         $"access_type=offline&" +
                                         $"redirect_uri={REDIRECT_URI}";
        }



        [HttpGet("signin-google-start")]
        public IActionResult GoogleSignInStart()
            => Redirect(_googleAuthorizationUrl);


        /*[HttpGet("signin-google")]
        public async Task<IActionResult> GoogleSignInAsync(string code, CancellationToken cancellationToken)
        {
            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer()
            {
                ClientSecrets = new ClientSecrets()
                {
                    ClientId = _googleSettings.ClientId,
                    ClientSecret = _googleSettings.ClientSecret,
                }
            });

            var tokenResponse = await flow.ExchangeCodeForTokenAsync(
                userId: "user",
                code: code,
                redirectUri: REDIRECT_URI,
                cancellationToken
            );

            var payload = await GoogleJsonWebSignature.ValidateAsync(tokenResponse.IdToken);

            var command = new UserAuthSocialLoginCommand(payload.Email, payload.GivenName, payload.FamilyName);

            var responseDto = await _mediatr.Send(command, cancellationToken);

            var queryParams = new Dictionary<string, string>()
            {

                {"access_token",responseDto.Data.Token },
                {"expiry_date",responseDto.Data.Expires.ToBinary().ToString()}

            };

          
            var formContent = new FormUrlEncodedContent(queryParams);

            var query = await formContent.ReadAsStringAsync(cancellationToken);

            //var redirectUrl = $"http://127.0.0.1:5173/social-login?{query}";

            return Redirect($"http://localhost:5067/social-login?email={email}&firstName={firstName}&lastName={lastName}");

        }*/


        [HttpGet("signin-google-start")]
        public IActionResult SignInGoogleStart()
      => Redirect(_googleAuthorizationUrl);

        [HttpGet("signin-google")]
        public async Task<IActionResult> SignInGoogleAsync(string code, CancellationToken cancellationToken)
        {
            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer()
            {
                ClientSecrets = new ClientSecrets()
                {
                    ClientId = _googleSettings.ClientId,
                    ClientSecret = _googleSettings.ClientSecret,
                }
            });

            var tokenResponse = await flow.ExchangeCodeForTokenAsync(
                userId: "user",
                code: code,
                redirectUri: REDIRECT_URI,
                cancellationToken
            );

            var payload = await GoogleJsonWebSignature.ValidateAsync(tokenResponse.IdToken);
            var command = new UserAuthSocialLoginCommand(payload.Email, payload.GivenName, payload.FamilyName);


            var responseDto = await _mediatr.Send(command, cancellationToken);


            var queryParams = new Dictionary<string, string>()
         {
             {"access_token",responseDto.Data.Token },
             {"expiry_date",responseDto.Data.Expires.ToBinary().ToString() },
         };

            var formContent = new FormUrlEncodedContent(queryParams);

            var query = await formContent.ReadAsStringAsync(cancellationToken);

            var redirectUrl = $"http://localhost:5262/social-login?{query}";

            return Redirect(redirectUrl);
        }

        [HttpPost("register")]

        public async Task<IActionResult> RegisterAsync(UserAuthRegisterCommand command,CancellationToken cancellationToken)
        {
            //throw new ArgumentNullException(command.FirstName, message: "First name is required");
            return Ok(await _mediatr.Send(command, cancellationToken));
        }


        [HttpPost("login")]

        public async Task<IActionResult> LoginAsync(UserAuthLoginCommand command, CancellationToken cancellationToken)
        {
            //throw new ArgumentNullException(command.FirstName, message: "First name is required");
            return Ok(await _mediatr.Send(command, cancellationToken));
        }



        [HttpGet("verify-email")]

        public async Task<IActionResult> VerifyEmailAsync([FromQuery]UserAuthVerifyEmailCommand command, CancellationToken cancellationToken)
        {
            
            return Ok(await _mediatr.Send(command, cancellationToken));
        }

        [HttpGet("forgot-password")]

        public async Task<IActionResult> ForgotPasswordAsync([FromQuery] UserAuthForgotPasswordCommand command, CancellationToken cancellationToken)
        {

            return Ok(await _mediatr.Send(command, cancellationToken));
        }


        [HttpGet("reset-password")]

        public async Task<IActionResult> ResetPasswordAsync([FromQuery] UserAuthResetPasswordCommand command, CancellationToken cancellationToken)
        {

            return Ok(await _mediatr.Send(command, cancellationToken));
        }


        [Authorize]
        [HttpGet("change-password")]

        public async Task<IActionResult> ChangePasswordAsync([FromQuery] UserAuthChangePasswordCommand command, CancellationToken cancellationToken)
        {

            return Ok(await _mediatr.Send(command, cancellationToken));
        }

    }
}
