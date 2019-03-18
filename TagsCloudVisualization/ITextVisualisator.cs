using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization
{
    public interface ITextVisualisator
    {
        ITextVisualisator SetFontSizes(double minFont, double maxFont);
        ITextVisualisator CreateTextImages(Dictionary<string, double> weights);
        ITextVisualisator SetFontTipe(string fontType);
        ITextVisualisator SetColors(Color[] colors);
        List<TextImage> GetStringImages();
    }
}
