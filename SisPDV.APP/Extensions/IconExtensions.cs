using FontAwesome.Sharp;

namespace SisPDV.APP.Extensions
{
    public static class IconExtensions
    {
        public static Image ToImage(this IconChar iconChar, int size, Color color)
        {
            var icon = new IconPictureBox
            {
                IconChar = iconChar,
                IconColor = color,
                IconSize = size,
                Size = new Size(size, size)
            };

            var bpm = new Bitmap(size, size);
            icon.DrawToBitmap(bpm, new Rectangle(0, 0, size, size));
            return bpm;
        }
    }
}
