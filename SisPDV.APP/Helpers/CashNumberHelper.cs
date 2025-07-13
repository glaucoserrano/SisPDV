using SisPDV.Application.DTOs.Cash;
using System.Text.Json;

namespace SisPDV.APP.Helpers
{
    public static class CashNumberHelper
    {
        public static int GetCashNumber(string pathSystem)
        {
            var pathJson = Path.Combine(pathSystem, "configs.json");

            if (!File.Exists(pathJson))
            {
                return 0;
            }

            try
            {
                var json = File.ReadAllText(pathJson);

                var cashConfig = JsonSerializer.Deserialize<CashConfigDTO>(json);
                return cashConfig?.CashNumber ?? 0;
            }
            catch
            {
                return 0;
            }
        }
        public static string GetPDVNumber()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            var cashNumber = CashNumberHelper.GetCashNumber(path);

            if (cashNumber == 0)
                return "Não configurado";

            return cashNumber.ToString() ?? "Não configurado";
        }
    }
}
