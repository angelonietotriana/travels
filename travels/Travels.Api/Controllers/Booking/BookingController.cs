using System.Drawing;
using Travels.Application.Booking.GetBooking;
using Travels.Application.Booking.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Travels.Api.Controllers.Bookling
{



    [ApiController]
    [Route("api/booking")]
    public class BookingController : ControllerBase
    {
        private readonly ISender _sender;

        public BookingController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(
            Guid id,
            CancellationToken cancellationToken
        )
        {
            var query = new GetBookingQuery(id);
            var resultado = await _sender.Send(query, cancellationToken);

            return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Booking(
            Guid id,
            BookingRequest request,
            CancellationToken cancellationToken
        )
        {
            var command = new BookingCommand
            (
                request.RoomId,
                request.HotelId,
                request.UserIdBooking,
                request.UserIdVendor,
                request.StartDate,
                request.EndDate
            );

            var response = await _sender.Send(command, cancellationToken);

            if (response.IsFailure)
            {
                return BadRequest(response.Error);
            }


            return CreatedAtAction(nameof(GetBooking), new { id = response.Value }, response.Value);


        }
    }

}