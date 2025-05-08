using SisPDV.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace SisPDV.Domain.Entities
{
    public class PrintSector : AuditableEntity
    {
        public int Id { get; set; }

        [Required]
        public string SectorName { get; set; } = string.Empty; // Nome do setor, ex: "Cozinha", "Bar"

        [Required]
        public string PrinterName { get; set; } = string.Empty; // Nome da impressora instalada no Windows

        public int NumberOfCopies { get; set; } = 1; // Quantidade de vias a imprimir

        public bool Active { get; set; } = true; // Permite ativar/desativar o setor

        public bool IsDefault { get; set; } = false; // Define se é o setor padrão de impressão de pedido
    }
}
