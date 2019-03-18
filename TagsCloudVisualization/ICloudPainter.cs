using System.Drawing;

namespace TagsCloudVisualization
{
    public interface ICloudPainter
    {
        Bitmap GetBitmap(
            string text,
            Color[] colors,
            int width = 100,
            int height = 100,
            double minFont = 1.0,
            double maxFont = 10.0,
            string fontName = "Arial"
        );
    }
}
