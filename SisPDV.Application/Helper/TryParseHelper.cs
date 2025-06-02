namespace SisPDV.Application.Helper
{
    public static class TryParseHelper
    {
        public static decimal SafeParseDecimal(string? value, string fieldName)
        {
            if (!decimal.TryParse(value, out var result))
                return 0;

            return result;
        }
    }
}
