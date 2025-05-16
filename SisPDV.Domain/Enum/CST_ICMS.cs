using System.ComponentModel;

namespace SisPDV.Domain.Enum
{
    public enum CST_ICMS
    {
        [Description("00 - Tributada integralmente")]
        TributadaIntegralmente = 0,

        [Description("10 - Tributada e com cobrança do ICMS por ST")]
        TributadaComST = 10,

        [Description("20 - Com redução de base de cálculo")]
        ReducaoBaseCalculo = 20,

        [Description("30 - Isenta ou não tributada com ST")]
        IsentaComST = 30,

        [Description("40 - Isenta")]
        Isenta = 40,

        [Description("41 - Não tributada")]
        NaoTributada = 41,

        [Description("50 - Suspensão")]
        Suspensao = 50,

        [Description("51 - Diferimento")]
        Diferimento = 51,

        [Description("60 - ICMS cobrado anteriormente por ST")]
        STAnterior = 60
    }
}
