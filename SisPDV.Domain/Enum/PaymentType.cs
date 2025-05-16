using System.ComponentModel;

namespace SisPDV.Domain.Enum
{
    public enum PaymentType
    {
        [Description("01 - A Vista")]
        AVista = 1,
        [Description("02 - A Prazo")]
        APrazo = 2,
        [Description("03 - Outros")]
        Outros = 3
    }
}
