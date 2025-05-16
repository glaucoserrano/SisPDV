using System.ComponentModel;

namespace SisPDV.Domain.Enum
{
    public enum CST_PIS
    {
        [Description("01 - Operação Tributável com alíquota básica")]
        AliquotaBasica = 1,

        [Description("02 - Operação Tributável com alíquota diferenciada")]
        AliquotaDiferenciada = 2,

        [Description("03 - Operação Tributável com base de cálculo por unidade")]
        AliquotaPorUnidade = 3,

        [Description("04 - Operação Tributável - Monofásica")]
        Monofasica = 4,

        [Description("05 - Operação Tributável - ST")]
        SubstituicaoTributaria = 5,

        [Description("06 - Operação Isenta")]
        Isenta = 6,

        [Description("07 - Operação com suspensão")]
        Suspensao = 7,

        [Description("08 - Operação sem incidência")]
        SemIncidencia = 8,

        [Description("09 - Outras operações")]
        Outras = 9
    }

}
