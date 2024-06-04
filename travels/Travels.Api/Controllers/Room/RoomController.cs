using MediatR;
using Microsoft.AspNetCore.Mvc;
using Travels.Application.Rooms.Commands;
using Travels.Application.Rooms.GetRoom;

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
        public async Task<IActionResult> GetRoom(
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var query = new GetRoomQuery(id);
            var result = await _sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Booms(
            Guid id,
            RoomRequest request,
            CancellationToken cancellationToken
        )
        {
            var command = new RoomCommand
            (
                request.Localization,
                request.NumberOfBeds,
                request.Capacity,
                request.Features,
                request.RoomType,
                request.PricePerPeriod,
                request.Maintenance,
                request.TotalPrice,
                request.FeaturesPrice,
                request.Price
            );

            var response = await _sender.Send(command, cancellationToken);

            if (response.IsFailure)
                return BadRequest(response.Error);
            
            
            return CreatedAtAction(nameof(GetRoom), new { id = response.Value }, response.Value);


        }
    }

}