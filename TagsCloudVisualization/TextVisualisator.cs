using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TagsCloudVisualization
{
    public class TextVisualisator : ITextVisualisator
    {
        private List<TextImage> _textImages;
        private Dictionary<string, double> _weights;

        public TextVisualisator()
        {
            _weights = new Dictionary<string, double>();
            _textImages = new List<TextImage>();
        }

        public ITextVisualisator CreateTextImages(Dictionary<string, double> weights)
        {
            _weights = weights;
            _textImages = new List<TextImage>();
            foreach (var weight in weights)
            {
                _textImages.Add(new TextImage(weight.Key));
            }
            return this;
        }


        public ITextVisualisator SetFontSizes(double minFont, double maxFont)
        {
            if (_weights.Count == 0) return this;

            var maxWeight = _weights.Values.Max();
            var minWeight = _weights.Values.Min();

            foreach (var textImage in _textImages)
            {
                var fontSize = (_weights[textImage.Text] > minWeight)
                    ? (maxFont - minFont) * (_weights[textImage.Text] - minWeight) / (maxWeight - minWeight) + minFont
                    : minFont;
                textImage.FontSize = (float) fontSize;
            }
            return this;
        }

        public ITextVisualisator SetFontTipe(string fontType = "Arial")
        {
            foreach (var textImage in _textImages)
            {
                textImage.FontType = fontType;
            }
            return this;
        }
        
        public ITextVisualisator SetColors(Color[] colors)
        {
            for (var i = 0; i < _textImages.Count; i++)
            {
                _textImages[i].Color = colors[i % colors.Length];
            }
            return this;
        }


        public List<TextImage> GetStringImages()
        {
            var proposedSize = new Size(int.MaxValue, int.MaxValue);
            var flags = TextFormatFlags.NoPadding;
            foreach (var textImage in _textImages)
            {
                var size = TextRenderer.MeasureText(textImage.Text,
                    textImage.Font, proposedSize, flags);
                textImage.Size = size;
            }
            return _textImages;
        }
    }
}
