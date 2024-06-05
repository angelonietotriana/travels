using MediatR;
using Microsoft.AspNetCore.Mvc;
using Travels.Application.User.Commands;
using Travels.Domain.Users;

namespace Travels.Api.Controllers.User
{

    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;

        public UserController(ISender sender)
        {
            _sender = sender;
        }


        [HttpPost]
        public async Task<IActionResult> Users(UserRequest request, CancellationToken cancellationToken)
        {
            var command = new UserCommand
            (
                new Nombre(request.Nombre),
                new Apellido(request.Apellido),
                new Email(request.Email),
                request.type);

            var response = await _sender.Send(command, cancellationToken);

            if (response.IsFailure)
                return BadRequest(response.Error);

            return Ok();


        }
    }

}