using MediatR;
using Microsoft.AspNetCore.Mvc;
using Travels.Application.Hotel.Commands;
using Travels.Application.Hotel.GetHotel;
using Travels.Domain.Hotels;

namespace Travels.Api.Controllers.Hotel
{

    [ApiController]
    [Route("api/hotel")]
    public class HotelController : ControllerBase
    {
        private readonly ISender _sender;

        public HotelController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotel(
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var query = new GetHotelQuery(id);
            var result = await _sender.Send(query, cancellationToken);

            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Booking(
            HotelRequest request,
            CancellationToken cancellationToken
        )
        {
            var command = new HotelCommand
            (
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

        [HttpPut]
        public async Task<IActionResult> HotelUpdate(Guid id,
                                                        HotelRequest request,
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

    }

}