using System;
using System.Collections.Generic;
using System.Drawing;
using TagsCloudVisualization.Extensions;

namespace TagsCloudVisualization
{
    public class CircularCloudLayouter : ICloudLayouter
    {
        private List<Rectangle> _rectangles;
        private readonly ISpiral _spiral;
        
        public CircularCloudLayouter(ISpiral spiral)
        {
            _spiral = spiral;       
        }

        private Point BalancePoint(PointF point) =>
            new Point((int)Math.Floor(point.X), (int)Math.Ceiling(point.Y));

        public void PrepareLayouter(Point center)
        {
            _spiral.PrepareSpiral(center);
            _rectangles = new List<Rectangle>();
        }

        private Point ChoosePoint()
        {
            Point point;
            do
            {
                var pointOnSpiral = _spiral.GetPoint();
                point = BalancePoint(pointOnSpiral);
            }
            while (_rectangles.ContainPoint(point));
            return point;
        }

        private Rectangle ChooseRectangle(Size size, Point point)
        {
            var rectangle = new Rectangle(point, size);
            while (_rectangles.IntersectRectangle(rectangle))
            {
                point = ChoosePoint();
                rectangle = new Rectangle(point, size);
            }
            return rectangle;
        }
        
        public Rectangle PutNextRectangle(Size rectangleSize)
        {
            if (rectangleSize.Width <= 0 || rectangleSize.Height <= 0) 
                throw new ArgumentException("Size have to be positive non zero number!");

            var point = ChoosePoint();
            var rectangle = ChooseRectangle(rectangleSize, point);
            _rectangles.Add(rectangle);
            return rectangle;
        }        
    }
}
