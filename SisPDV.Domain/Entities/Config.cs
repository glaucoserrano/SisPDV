using SisPDV.Domain.Entities.Base;
using SisPDV.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace SisPDV.Domain.Entities
{
    public class Config : AuditableEntity
    {
        [Key]
        public int Id { get; set; }

        //Certificado Digital
        [Required,MaxLength(255)]
        public string DigitalCertificate { get; set; } = string.Empty; //Certificado Digital
        
        [Required,MaxLength(100)]
        public string PasswordCertificate { get; set; } = string.Empty; // Senha Certificado
        public bool CertificateA1 { get; set; } // Certificado A1 ou A3

        //Configuração de NFC-e
        public bool NFCeEnabled { get; set; } = false; // Habilitar uso de NF-e

        [Required, MaxLength(5)]
        public string VersionDF { get; set; } = "4.00"; // Versão da NFC-e

        [Required]
        public int Model { get; set; } = 65; //Modelo NFC-e

        [Required]
        public int Serial { get; set; } // Série NFC-e

        [Required]
        public int InitialNumber { get; set; } // Numero Inicial da NFC-e

        [Required]
        public EnvironmentNFCe Environment { get; set; } // Ambiente "1" Produção "2" Homologação

        [Required,MaxLength(36)]
        public string CSC { get; set; } = string.Empty; //CSC - Verficiar no SEFAZ ou com Contador

        [Required,MaxLength(6)]
        public string CSCId { get; set; } = string.Empty; //CSCId Verificar com contador
        public  bool Print { get; set; } // Imprimir NFc-e

        [Required]
        public TypeEmission TypeEmission { get; set; } = TypeEmission.Normal; //Tipo de Emissão

        [Required, MaxLength(255)]
        public string XMLPath { get; set; } = string.Empty;//Caminho para gerar os Path XML

        // NF-e (Modelo 55)
        public bool NFeEnabled { get; set; } = false; // Habilitar uso de NF-e

        [Required, MaxLength(5)]
        public string NFeVersionDF { get; set; } = "4.00"; // Versão do XML da NF-e

        [Required]
        public int NFeModel { get; set; } = 55; // Modelo fiscal da NF-e

        [Required]
        public int NFeSerial { get; set; }

        [Required]
        public int NFeInitialNumber { get; set; }

        [Required, MaxLength(255)]
        public string NFeXmlPath { get; set; } = string.Empty;

        [Required]
        public EnvironmentNFCe NFeEnvironment { get; set; } = EnvironmentNFCe.Homologacao;

        public bool NFePrint { get; set; } = false;

        public bool NFeSavePDF { get; set; } = false;

        [MaxLength(100)]
        public string NFeDestinationEmail { get; set; } = string.Empty;

        [Required]
        public NFeFinality NFeFinality { get; set; } = NFeFinality.Normal;

        [Required]
        public PresenceIndicator NFePresenceIndicator { get; set; } = PresenceIndicator.Presencial;

        [Required]
        public PaymentType NFePaymentForm { get; set; } = PaymentType.Outros;
        //Configuraçoes Gerais
        public bool UseStockControl { get; set; } // Usar Controle de Estoque
        public bool SalesZeroStock { get; set; } //Permite venda com estoque zerado
        public bool OrderPrint { get; set; } // Imprimir Pedido
        
        [MaxLength(255)]
        public string BackupPath { get; set; } = string.Empty; // Caminho do backup automático

        public bool AutoCloseOrder { get; set; } // Fechar automaticamente pedidos ao emitir NFC-e

        public bool UsePrintSector { get; set; }
    }
}
