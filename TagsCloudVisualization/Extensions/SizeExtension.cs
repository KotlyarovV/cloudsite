using System.Drawing;

namespace TagsCloudVisualization.Extensions
{
    public static class SizeExtension
    {
        public static Point GetCenter(this Size size) => new Point(size.Width / 2, size.Height / 2);
    }
}
