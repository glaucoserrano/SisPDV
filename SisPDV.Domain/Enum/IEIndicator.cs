using System.ComponentModel;

namespace SisPDV.Domain.Enum
{
    public enum IEIndicator
    {
        [Description("01 - Contribuinte ICMS")]
        ContribuinteICMS = 1, // 1 = Contribuinte ICMS
        [Description("02 - Contribuinte isento de inscrição")]
        ContribuinteIsento = 2, // 2 = Contribuinte isento de inscrição
        [Description("09 - Não Contribuinte")]
        NaoContribuinte = 9     // 9 = Não contribuinte
    }
}
