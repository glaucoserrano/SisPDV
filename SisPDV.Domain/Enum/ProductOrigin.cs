using System.ComponentModel;

namespace SisPDV.Domain.Enum
{
    public enum ProductOrigin
    {
        [Description("0 - Nacional")]
        Nacional = 0,

        [Description("1 - Estrangeira - Importação direta")]
        EstrangeiraImportacaoDireta = 1,

        [Description("2 - Estrangeira - Adquirida no mercado interno")]
        EstrangeiraMercadoInterno = 2,

        [Description("3 - Nacional - Conteúdo de importação superior a 40%")]
        NacionalConteudoImportacao40 = 3,

        [Description("4 - Nacional - Produzida com processo produtivo básico")]
        NacionalProcessoProdutivoBasico = 4,

        [Description("5 - Nacional - Conteúdo de importação inferior a 40%")]
        NacionalConteudoImportacao40Menor = 5,

        [Description("6 - Estrangeira - Sem similar nacional (Res. CAMEX)")]
        EstrangeiraSemSimilar = 6,

        [Description("7 - Nacional - Conteúdo importado inferior a 70%")]
        NacionalConteudoImportado70 = 7,

        [Description("8 - Nacional - Bens importados sem similar nacional")]
        NacionalBensImportadosSemSimilar = 8
    }
}
