using MediatR;
using Microsoft.AspNetCore.Mvc;
using Travels.Application.Hotel.Commands;
using Travels.Application.HotelsRooms.Commands;
using Travels.Application.HotelsRooms.GetHotelsRooms;
using Travels.Domain.Hotels;

namespace Travels.Api.Controllers.RelatedHotelsRooms
{

    [ApiController]
    [Route("related/hotelsRooms")]
    public class HotelsRoomsController : ControllerBase
    {
        private readonly ISender _sender;

        public HotelsRoomsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{hotelId}/{roomId}")]
        public async Task<IActionResult> GetHotelsRooms(Guid hotelId, Guid roomId, CancellationToken cancellationToken)
        {
            var query = new GetHotelsRoomsQuery(hotelId, roomId);
            var result = await _sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelRoom(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetHotelRoomQuery(id);
            var result = await _sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> HotelsRooms(HotelsRoomsRequest request, CancellationToken cancellationToken)
        {
            var command = new HotelsRoomsCommand
                (request.HotelId,
                 request.RoomId,
                 true);

            var response = await _sender.Send(command, cancellationToken);

            if (response.IsFailure)
                return BadRequest(response.Error);
            

            return CreatedAtAction(nameof(GetHotelRoom), new { id = response.Value }, response.Value);
        }
        /*
        [HttpPut]
        public async Task<IActionResult> HotelUpdate(Guid id,
                                                        HotelsRoomsRequest request,
                                                        CancellationToken cancellationToken
        )
        {
            var command = new HotelCommandUpdated
            (
                id,
                new Business(request.BusinessName, request.Nit),
                new Address(request.City, request.Neighborhood, request.Zone, request.Numeration),
                new TotalCapacity(request.TotalCapacity),
                new Stars(request.Stars),
                request.State,
                request.RoomId
            );

            var response = await _sender.Send(command, cancellationToken);

            if (response.IsFailure)
                return BadRequest(response.Error);


            return CreatedAtAction(nameof(GetHotel), new { id = response.Value }, response.Value);
        }
        */

    }

}