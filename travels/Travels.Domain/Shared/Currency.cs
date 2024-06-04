namespace Travels.Domain.Shared
{

    public record Currency(decimal Amount)
    {
        public static Currency operator +(Currency primero, Currency segundo)
        {
            return new Currency(primero.Amount + segundo.Amount);
        }


        public static Currency Zero() => new(0);
       
        public bool IsZero() => this == Zero();
    };
    
}