using System.ComponentModel;

namespace SisPDV.Domain.Enum
{
    public enum PaymentType
    {
        [Description("1 - Dinheiro")]
        Dinheiro,

        [Description("2 - Cartão de Crédito")]
        CartaoCredito,

        [Description("3 - Cartão de Débito")]
        CartaoDebito,

        [Description("4 - Pix")]
        Pix,

        [Description("5 - Boleto")]
        Boleto,

        [Description("6 - Cheque")]
        Cheque,

        [Description("7 - Outros")]
        Outros
    }
}
