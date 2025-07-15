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
    }
}
