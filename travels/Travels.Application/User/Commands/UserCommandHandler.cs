using Travels.Application.Abstractions.Clock;
using Travels.Application.Abstractions.Messaging;
using Travels.Application.Exceptions;
using Travels.Domain.Abstractions;
using Travels.Domain.Bookings;
using Travels.Domain.Users;

namespace Travels.Application.User.Commands
{

    internal sealed class UserCommandHandler :
    ICommandHandler<UserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IDateTimeProvider dateTimeProvider
        )
        {

            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(UserCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var user = UserEntity.Create(
                    request!.nombre,
                    request!.apellido,
                    request.email,
                    request!.type);

                _userRepository.Add(user);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return user.Id;
            }
            catch (ConcurrencyException)
            {
                return Result.Failure<Guid>(BookingErrors.CreatedUser);
            }

        }
    }
}