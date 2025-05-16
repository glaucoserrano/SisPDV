using System.ComponentModel;

namespace SisPDV.Domain.Enum
{
    public enum NFeFinality
    {
        [Description("01 - Normal")]
        Normal = 1,
        [Description("02 - Complementar")]
        Complementar = 2,
        [Description("03  - Ajuste")]
        Ajuste = 3,
        [Description("04 - Devolução")]
        Devolucao = 4
    }
}
