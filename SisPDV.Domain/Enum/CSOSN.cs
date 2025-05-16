using System.ComponentModel;

namespace SisPDV.Domain.Enum
{
    public enum CSOSN
    {
        [Description("101 - Tributada pelo Simples Nacional com permissão de crédito")]
        SNComCredito = 101,

        [Description("102 - Tributada pelo Simples Nacional sem permissão de crédito")]
        SNSemCredito = 102,

        [Description("103 - Isenção do ICMS no Simples Nacional")]
        SNIsento = 103,

        [Description("201 - Com substituição tributária com permissão de crédito")]
        SNSTComCredito = 201,

        [Description("202 - Com substituição tributária sem permissão de crédito")]
        SNSTSemCredito = 202,

        [Description("500 - ICMS cobrado anteriormente por substituição tributária")]
        STAnterior = 500,

        [Description("900 - Outros")]
        Outros = 900
    }
}
