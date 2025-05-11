namespace SisPDV.Domain.Helpers
{
    public class FormatHelper
    {
        public static string OnlyNumber(string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }

    }
}
