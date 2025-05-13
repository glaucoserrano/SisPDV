namespace SisPDV.APP.Helpers
{
    public static class SelectedHelper
    {
        public static string? SelectedPath(TextBox txtPath)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Selecione uma pasta";
                folderDialog.ShowNewFolderButton = true;

                return folderDialog.ShowDialog() == DialogResult.OK
                    ? folderDialog.SelectedPath
                    : null;
            }
        }
        public static string? SelectCertificateFile()
        {
            using var fileDialog = new OpenFileDialog
            {
                Title = "Selecione o certificado digital (.pfx)",
                Filter = "Certificado Digital (*.pfx)|*.pfx",
                CheckFileExists = true,
                CheckPathExists = true
            };

            return fileDialog.ShowDialog() == DialogResult.OK
                ? fileDialog.FileName
                : null;
        }
    }
}
