using Travels.Domain.Shared;

namespace Travels.Domain.Rooms;

public record DetailPrice(
    Currency PricePerPeriod,
    Currency Maintenance,
    Currency Accesories,
    Currency TotalPrice
);