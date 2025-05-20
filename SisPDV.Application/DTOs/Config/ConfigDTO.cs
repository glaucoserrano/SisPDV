using SisPDV.Domain.Enum;

namespace SisPDV.Application.DTOs.Config
{
    public class ConfigDTO
    {
        // Certificado Digital
        public string DigitalCertificate { get; set; } = string.Empty;
        public string PasswordCertificate { get; set; } = string.Empty;
        public bool CertificateA1 { get; set; }

        // NFC-e
        public bool NFCeEnabled { get; set; }
        public string VersionDF { get; set; } = "4.00";
        public int Model { get; set; } = 65;
        public int Serial { get; set; }
        public int InitialNumber { get; set; }
        public EnvironmentNFCe Environment { get; set; }
        public string CSC { get; set; } = string.Empty;
        public string CSCId { get; set; } = string.Empty;
        public bool Print { get; set; }
        public TypeEmission TypeEmission { get; set; }
        public string XMLPath { get; set; } = string.Empty;

        // NF-e
        public bool NFeEnabled { get; set; }
        public string NFeVersionDF { get; set; } = "4.00";
        public int NFeModel { get; set; } = 55;
        public int NFeSerial { get; set; }
        public int NFeInitialNumber { get; set; }
        public string NFeXmlPath { get; set; } = string.Empty;
        public EnvironmentNFCe NFeEnvironment { get; set; }
        public bool NFePrint { get; set; }
        public bool NFeSavePDF { get; set; }
        public string NFeDestinationEmail { get; set; } = string.Empty;
        public NFeFinality NFeFinality { get; set; }
        public PresenceIndicator NFePresenceIndicator { get; set; }
        public PaymentType NFePaymentForm { get; set; }

        // Gerais
        public bool UseStockControl { get; set; }
        public bool SalesZeroStock { get; set; }
        public bool OrderPrint { get; set; }
        public string BackupPath { get; set; } = string.Empty;
        public bool AutoCloseOrder { get; set; }

        public bool UsePrintSector { get; set; }
    }
}
