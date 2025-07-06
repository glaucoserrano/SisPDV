namespace SisPDV.Application.Helper
{
    public static class FileUploadHelper
    {
        public static string UploadImage(string sourcePath, string destinationFolder, string? forcedName = null)
        {
            var extension = Path.GetExtension(sourcePath);
            var fileName = forcedName ?? $"{Guid.NewGuid()}{extension}";

            // Garante que o destinationFolder seja relativo
            destinationFolder = destinationFolder.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            var destFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, destinationFolder);

            var destPath = Path.Combine(destFolderPath, fileName);

            Directory.CreateDirectory(Path.GetDirectoryName(destPath)!);
            File.Copy(sourcePath, destPath, true);
            return destPath;
        }

    }
}
