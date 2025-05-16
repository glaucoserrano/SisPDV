using System.ComponentModel;

namespace SisPDV.Domain.Enum
{
    public enum PresenceIndicator
    {
        [Description("01 - Presencial")]
        Presencial = 1,
        [Description("02 - Não Presencial")]
        NaoPresencial = 2,
        [Description("03 - Internet")]
        Internet = 3,
        [Description("04 - TeleAtendimento")]
        Teleatendimento = 4,
        [Description("09 - Outros")]
        Outros = 9
    }
}
