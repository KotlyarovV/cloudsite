using System.Drawing;

namespace TagsCloudVisualization
{
    public interface ISpiral
    {
        PointF GetPoint();
        void PrepareSpiral(Point center);
    }
}
