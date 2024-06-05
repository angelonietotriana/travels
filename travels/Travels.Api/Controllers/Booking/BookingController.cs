using MediatR;
using Microsoft.AspNetCore.Mvc;
using Travels.Api.Controllers.Hotel;
using Travels.Application.Booking.Commands;
using Travels.Application.Booking.GetBooking;
using Travels.Application.Hotel.Commands;
using Travels.Domain.Bookings;
using Travels.Domain.Hotels;

namespace Travels.Api.Controllers.Booking
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
        public async Task<IActionResult> Booking(BookingRequest request, CancellationToken cancellationToken)
        {
            var command = new BookingCommand
            (
                request.RoomId,
                request.HotelId,
                request.UserIdBooking,
                request.UserIdSells,
                DateOnly.Parse(request.StartDate),
                DateOnly.Parse(request.EndDate)
            );

            var response = await _sender.Send(command, cancellationToken);

            if (response.IsFailure)
            {
                return BadRequest(response.Error);
            }


            return CreatedAtAction(nameof(GetBooking), new { id = response.Value }, response.Value);


        }

        [HttpPut]
        public async Task<IActionResult> BookingUpdate(Guid id, BookingRequest request, CancellationToken cancellationToken
)
        {
            var command = new BookingCommandUpdate
            (
                id,
                request.RoomId,
                request.HotelId,
                request.UserIdBooking,
                request.UserIdSells,
                request.StartDate,
                request.EndDate,
                request.Status,
                request.ConfirmDate,
                request.RejectDate,
                request.CompleteDate,
                request.CancelationDate
            );

            var response = await _sender.Send(command, cancellationToken);

            if (response.IsFailure)
                return BadRequest(response.Error);


            return CreatedAtAction(nameof(GetBooking), new { id = response.Value }, response.Value);
        }


        [HttpGet("")]
        public async Task<IActionResult> GetAllBooking(CancellationToken cancellationToken)
        {
            
            var query = new GetBookingQueryAll();
            var resultado = await _sender.Send(query, cancellationToken);

            return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
            
        }

    }

}