using System.ComponentModel.DataAnnotations.Schema;
using Travels.Domain.Abstractions;
using Travels.Domain.Rooms.Events;
using Travels.Domain.Shared;

namespace Travels.Domain.Rooms
{
    public sealed class RoomEntity : Entity
    {
        public Localization? Localization {  get; private set; }
        public NumberOfBeds? NumberOfBeds { get; private set; }
        public Capacity? Capacity { get; private set; }
        public List<Features>? Features {  get; private set; }
        public RoomType RoomType { get; private set; }

        public Currency? PricePerPeriod { get; private set; }
        public Currency? Maintenance { get; private set; }

        public Currency? TotalPrice { get; private set; }
        public Currency? FeaturesPrice { get; private set; }
        public Currency Price { get; private set; }

        public RoomEntity()
        {
            
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="localization"></param>
        /// <param name="numberOfBeds"></param>
        /// <param name="capacity"></param>
        /// <param name="features"></param>
        /// <param name="roomType"></param>
        /// <param name="pricePerPeriod"></param>
        /// <param name="maintenance"></param>
        /// <param name="totalPrice"></param>
        /// <param name="FeaturesPrice"></param>
        /// <param name="price"></param>
        internal RoomEntity(Localization? localization,
                          NumberOfBeds? numberOfBeds, 
                          Capacity? capacity, 
                          List<Features>? features, 
                          RoomType roomType, 
                          Currency? pricePerPeriod, 
                          Currency? maintenance, 
                          Currency? totalPrice,
                          Currency? FeaturesPrice,
                          Currency price)
        {
            Localization = localization;
            NumberOfBeds = numberOfBeds;
            Capacity = capacity;
            Features = features;
            RoomType = roomType;
            PricePerPeriod = pricePerPeriod;
            Maintenance = maintenance;
            TotalPrice = totalPrice;
            this.FeaturesPrice = FeaturesPrice; 
            Price = price;
        }

        /// <summary>
        /// create to entity in this method.
        /// </summary>
        /// <param name="localization"></param>
        /// <param name="numberOfBeds"></param>
        /// <param name="capacity"></param>
        /// <param name="features"></param>
        /// <param name="roomEntity"></param>
        /// <param name="roomType"></param>
        /// <param name="price"></param>
        /// <param name="pricePerPeriod"></param>
        /// <param name="maintenance"></param>
        /// <param name="totalPrice"></param>
        /// <returns></returns>
        public static RoomEntity Create(Localization? localization,
                                        NumberOfBeds? numberOfBeds,
                                        Capacity? capacity,
                                        List<Features>? features,
                                        RoomType roomType,
                                        Currency? pricePerPeriod,
                                        Currency? maintenance,
                                        Currency? totalPrice,
                                        Currency? FeaturesPrice,
                                        Currency price
                                        )
        {
            var room = new RoomEntity(localization, numberOfBeds, capacity, features, roomType, pricePerPeriod, maintenance, totalPrice, FeaturesPrice, price);
            room.RaiseDomainEvent(new RoomCreatedDomainEvent(room.Id));

            return room;


        }
    }
}
