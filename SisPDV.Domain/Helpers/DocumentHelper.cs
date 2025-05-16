namespace SisPDV.Domain.Helpers
{
    public static class DocumentHelper
    {
        public static string FormatCpfCnpj(string document)
        {
            if (string.IsNullOrWhiteSpace(document))
                return string.Empty;

            document = new string(document.Where(char.IsDigit).ToArray()); // remove qualquer caractere não numérico

            return document.Length switch
            {
                11 => Convert.ToUInt64(document).ToString(@"000\.000\.000\-00"),
                14 => Convert.ToUInt64(document).ToString(@"00\.000\.000\/0000\-00"),
                _ => document // retorna sem formatação se não for 11 ou 14 dígitos
            };
        }
    }
}
