using MediatR;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Login;
using MextFullstackSaaS.Application.Features.UserAuth.Commands.Register;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MextFullstackSaaS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAuthController : ControllerBase
    {

        public readonly ISender? _mediatr;

        public UsersAuthController(ISender? mediatr)
        {
            _mediatr = mediatr;
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

    }
}
