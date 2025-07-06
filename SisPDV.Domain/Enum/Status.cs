using System.ComponentModel;

namespace SisPDV.Domain.Enum
{
    public enum Status
    {
        [Description("Ativos")]
        Active = 1,
        [Description("Inativos")]
        Inactive = 0
    }
}
