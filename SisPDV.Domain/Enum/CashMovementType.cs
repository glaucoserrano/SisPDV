using System.ComponentModel;

namespace SisPDV.Domain.Enum
{
    public enum CashMovementType
    {
        [Description("Abertura de Caixa")]
        Opening = 1,
        [Description("Fechamento de Caixa")]
        Closing = 2,
        [Description("Suprimento de Caixa")]
        Entry = 3,
        [Description("Sangria de Caixa")]
        Exit = 4,
        [Description("Venda")]
        Sale = 5,
        [Description("Ajuste de Caixa")]
        Adjustment = 6
    }
}
