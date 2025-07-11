using System.ComponentModel;

namespace SisPDV.Domain.Enum
{
    public enum StockMovementType
    {
        [Description("Entrada")]
        Entry = 0,
        [Description("Saída")]
        Exit = 1,
        [Description("Ajuste")]
        Adjustment = 2
    }

}
