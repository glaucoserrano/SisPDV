namespace SisPDV.APP.Helpers
{
    public static class ReportTextHelper
    {
        public static string CenterLine(string text, int totalWidth = 32)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            int spaces = (totalWidth - text.Length) / 2;
            return new string(' ', Math.Max(spaces, 0)) + text;
        }
        public static void ConfigureReceiptPreview(RichTextBox rtpPreview)
        {
            rtpPreview.Font = new Font("Courier New", 10); // Monoespaçada
            rtpPreview.WordWrap = false;                   // Evita quebra automática
            rtpPreview.ReadOnly = true;                    // Opcional: só leitura
            rtpPreview.BackColor = Color.White;            // Deixa com fundo de cupom
        }
        public static string FormatLine(string label, decimal value, bool isNegative = false)
        {
            var val = value.ToString("C2"); // Formata como moeda, exemplo: R$ 200,00
            return $"{label,-18} {(isNegative ? "-" : "")}{val,10}";
        }
    }
}
