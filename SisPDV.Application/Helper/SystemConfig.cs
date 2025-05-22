using SisPDV.Application.DTOs.Config;

namespace SisPDV.Application.Helper
{
    public static class SystemConfig
    {
        public static ConfigDTO Current { get; set; } = new ConfigDTO();

        public static void Load(ConfigDTO config)
        {
            Current = config;
        }

        public static bool UseStockControl => Current.UseStockControl;
        public static bool UsePrintSector => Current.UsePrintSector;
        public static bool SalesZeroStock => Current.SalesZeroStock;

    }
}
