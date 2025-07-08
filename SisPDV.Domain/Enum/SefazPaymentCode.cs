using System.ComponentModel;

namespace SisPDV.Domain.Enum
{
    public enum SefazPaymentCode
    {
        [Description("01 - Dinheiro")]
        Dinheiro = 01,

        [Description("02 - Cheque")]
        Cheque = 02,

        [Description("03 - Cartão de Crédito")]
        CartaoCredito = 03,

        [Description("04 - Cartão de Débito")]
        CartaoDebito = 04,

        [Description("05 - Crédito Loja")]
        CreditoLoja = 05,

        [Description("10 - Vale Alimentação")]
        ValeAlimentacao = 10,

        [Description("11 - Vale Refeição")]
        ValeRefeicao = 11,

        [Description("12 - Vale Presente")]
        ValePresente = 12,

        [Description("13 - Vale Combustível")]
        ValeCombustivel = 13,

        [Description("15 - Boleto Bancário")]
        BoletoBancario = 15,

        [Description("16 - Depósito Bancário")]
        DepositoBancario = 16,

        [Description("17 - PIX")]
        Pix = 17,

        [Description("18 - Transferência Bancária")]
        TransferenciaBancaria = 18,

        [Description("19 - Programa Fidelidade")]
        ProgramaFidelidade = 19,

        [Description("90 - Sem Pagamento")]
        SemPagamento = 90,

        [Description("99 - Outros")]
        Outros = 99
    }
}
