using MediatR;
using Travels.Application.Abstractions.Email;
using Travels.Domain.Bookings;
using Travels.Domain.Bookings.Events;
using Travels.Domain.Users;

namespace Travels.Application.Booking.Commands
{

    internal sealed class BookingDomainEventHandler
    : INotificationHandler<BookingDomainEvent>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public BookingDomainEventHandler(
            IBookingRepository bookingRepository,
            IUserRepository userRepository,
            IEmailService emailService
            )
        {
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task Handle(
            BookingDomainEvent notification,
            CancellationToken cancellationToken
        )
        {
            var booking = await _bookingRepository
            .GetByIdAsync(notification.Id, cancellationToken);

            if (booking is null)
            {
                return;
            }

            var userBooking = await _userRepository.GetByIdAsync(
                booking.UserIdBooking,
                cancellationToken
            );

            if (userBooking is null)
                return;

            await _emailService.SendAsync(
                userBooking.Email!,
                "Alquiler Reservado",
                "Tienes que confirmar esta reserva de lo contrario se va a perder"
            );

        }
    }
}