using System.ComponentModel;

namespace SisPDV.Domain.Enum
{
    public enum TaxRegime
    {
        [Description("Selecione")]
        None = 0,
        [Description("Simples Nacional")]
        SimplesNacional = 1,
        [Description("Simples Nacional Excesso SubLimite")]
        SimplesNacionalExcessoSubLimite = 2,
        [Description("Regime Normal")]
        RegimeNormal = 3
    }
}
