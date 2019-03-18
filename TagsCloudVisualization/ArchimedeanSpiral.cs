using System;
using System.Drawing;

namespace TagsCloudVisualization
{
    public class ArchimedeanSpiral : ISpiral
    {
        /*
         * Realization of http://hijos.ru/2011/03/09/arximedova-spiral/ formulas
        */

        private readonly double _spiralRadius;
        private Point _center;
        private readonly double _angleStep;
        private double _spiralAngle;

        public ArchimedeanSpiral(double angleStep = 0.01, double spiralRadius = 1)
        {
            _angleStep = angleStep;
            _spiralRadius = spiralRadius;
        }

        public PointF GetPoint()
        {
            _spiralAngle += _angleStep;
            
            var x = (float) (_center.X + _spiralRadius * _spiralAngle * Math.Cos(_spiralAngle));
            var y = (float) (_center.Y + _spiralRadius * _spiralAngle * Math.Sin(_spiralAngle));

            return new PointF(x, y);
        }

        public void PrepareSpiral(Point center)
        {
            _spiralAngle = 0;
            _center = center;
        }
    }
}
