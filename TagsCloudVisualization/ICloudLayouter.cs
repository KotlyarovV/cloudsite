using System.Drawing;

namespace TagsCloudVisualization
{
    public interface ICloudLayouter
    {
        Rectangle PutNextRectangle(Size rectangleSize);
        void PrepareLayouter(Point center);
    }
}
