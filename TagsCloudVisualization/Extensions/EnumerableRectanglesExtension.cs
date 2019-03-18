using System.Collections.Generic;
using System.Drawing;
using System.Linq;


namespace TagsCloudVisualization.Extensions
{
    public static class EnumerableRectanglesExtension
    {
        public static bool ContainPoint(this IEnumerable<Rectangle> rectangles, Point point) =>
            rectangles.Any(r => r.Contains(point));

        public static bool IntersectRectangle(this IEnumerable<Rectangle> rectangles, Rectangle rectangle) =>
            rectangles.Any(r => r.IntersectsWith(rectangle));

        public static bool AnyIntersected(this IEnumerable<Rectangle> rectangles) =>
            rectangles.Any(x => rectangles.Any(y => x.IntersectsWith(y) && y != x));
    }
}
