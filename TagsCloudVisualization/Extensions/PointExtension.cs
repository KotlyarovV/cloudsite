using System;
using System.Drawing;

namespace TagsCloudVisualization.Extensions
{
    public static class PointExtension
    {
        public static double GetDistance(this Point point1, Point point2)
        {
            var x = (double) (point1.X - point2.X);
            var y = (double)(point1.Y - point2.Y);
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
    }
}
