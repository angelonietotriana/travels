using MediatR;
using Microsoft.AspNetCore.Mvc;
using Travels.Application.Rooms.Commands;
using Travels.Application.Rooms.GetRoom;
using Travels.Domain.Rooms;
using Travels.Domain.Shared;

namespace Travels.Api.Controllers.Room
{

    [ApiController]
    [Route("api/room")]
    public class RoomController : ControllerBase
    {
        private readonly ISender _sender;

        public RoomController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(Guid id,
                                                CancellationToken cancellationToken)
        {
            var query = new GetRoomQuery(id);
            var resultado = await _sender.Send(query, cancellationToken);

            return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Rooms(RoomRequest request, CancellationToken cancellationToken)
        {
            var command = new RoomCommand
            (
                new Localization(request.Floor, request.View),
                new NumberOfBeds(request.NumberOfBeds),
                new Capacity(request.Capacity),
                request.Features,
                request.RoomType,
                new Currency(request.PricePerPeriod),
                new Currency(request.Maintenance),
                new Currency(request.TotalPrice),
                new Currency(request.FeaturesPrice),
                new Currency(request.Price)
            );

            var response = await _sender.Send(command, cancellationToken);

            if (response.IsFailure)
                return BadRequest(response.Error);


            return CreatedAtAction(nameof(GetRoom), new { id = response.Value }, response.Value);


        }
    }

}