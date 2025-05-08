namespace SisPDV.Domain.Enum
{
    public enum TypeEmission
    {
        Normal = 1,               // 1 - Emissão normal (não em contingência)
        ContingenciaFS = 2,       // 2 - Contingência FS (impressão formulário de segurança)
        ContingenciaSCAN = 3,     // 3 - Contingência SCAN (Sefaz Virtual de Contingência)
        ContingenciaDPEC = 4,     // 4 - Contingência DPEC (Declaração Prévia)
        ContingenciaFSDA = 5,     // 5 - Contingência FS-DA
        ContingenciaSVCAN = 6,    // 6 - SVC-AN (Sefaz Virtual Contingência Ambiente Nacional)
        ContingenciaSVCRS = 7,    // 7 - SVC-RS (Sefaz Virtual Contingência Rio Grande do Sul)
        ContingenciaOffline = 9  // 9 - Contingência Offline da NFC-e
    }
}
