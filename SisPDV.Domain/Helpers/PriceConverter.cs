namespace SisPDV.Domain.Helpers
{
    public static class PriceConverter
    {
        public static int ToCents(decimal? value) => value.HasValue ? (int)Math.Round(value.Value * 100) : 0;

        public static decimal FromCents(int? value) =>  value.HasValue ?  value.Value / 100m : 0;
    }
}
