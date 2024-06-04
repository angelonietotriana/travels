namespace Travels.Domain.Shared
{

    public record CurrencyType
    {

        public static readonly CurrencyType None = new("");
        public static readonly CurrencyType Usd = new("USD");
        public static readonly CurrencyType Eur = new("EUR");
        public static readonly CurrencyType Cop = new("COP");

        private CurrencyType(string code) => Code = code;

        public string? Code { get; init; }

        public static readonly IReadOnlyCollection<CurrencyType> All = new[]
        {
        Usd,
        Eur
    };

        public static CurrencyType FromCodigo(string code)
        {
            return All.FirstOrDefault(c => c.Code == code) ??
                throw new ApplicationException("El tipo de moneda es invalido");
        }

    }
}