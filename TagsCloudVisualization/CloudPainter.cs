using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TagsCloudVisualization.Extensions;

namespace TagsCloudVisualization
{
    public class CloudPainter : ICloudPainter
    {
        private readonly ICloudLayouter _cloudLayouter;
        private readonly IAnalysator _lexicAnalysator;
        private readonly ITextVisualisator _textVisualisator;
        private readonly IWordExtractor _wordExtractor;
        private readonly IFormatter _formatter;
        private readonly IFilter _filter;
        private readonly ITextCleaner _textCleaner;

        public CloudPainter(
            IWordExtractor wordExtractor,
            IFormatter formatter,
            IFilter filter,
            IAnalysator lexicAnalysator,
            ICloudLayouter cloudLayouter,
            ITextVisualisator textVisualisator,
            ITextCleaner textCleaner
            )
        {
            _cloudLayouter = cloudLayouter;
            _lexicAnalysator = lexicAnalysator;
            _textVisualisator = textVisualisator;
            _wordExtractor = wordExtractor;
            _formatter = formatter;
            _filter = filter;
            _textCleaner = textCleaner;
        }

        private IEnumerable<TextImage> GetStringImages(
            string text,
            Color[] colors,
            double minFont = 1.0, 
            double maxFont = 10.0, 
            string fontName = "Arial"      
            )
        {
            var textWithoutSigns = _textCleaner.RemoveSigns(text);

            var words = _wordExtractor
                .ExtractWords(textWithoutSigns)
                .Where(_filter.IsNecessaryPartOfSpeech)
                .Select(_formatter.GetOriginal)
                .ToArray();

            var weights = _lexicAnalysator.GetWeights(words);
            
            var stringImages = _textVisualisator
                .CreateTextImages(weights)
                .SetFontSizes(minFont, maxFont)
                .SetColors(colors)
                .SetFontTipe(fontName)
                .GetStringImages();

            return stringImages;
        }
        
        public Bitmap GetBitmap(
            string text, 
            Color[] colors,
            int width = 100,
            int height = 100,
            double minFont = 1.0,
            double maxFont = 10.0,
            string fontName = "Arial"
            )
        {   
            var bitmap = new Bitmap(width, height);
            var center = bitmap.Size.GetCenter();
            var graphics = Graphics.FromImage(bitmap);
            var textImages = GetStringImages(text, colors, minFont, maxFont, fontName);
            textImages = textImages
                .OrderBy(stringImage => -stringImage.Size.Width * stringImage.Size.Height);
             
            var flags = TextFormatFlags.NoPadding | TextFormatFlags.NoClipping;
            _cloudLayouter.PrepareLayouter(center);

            foreach (var textImage in textImages)
            {
                var rectangle = _cloudLayouter.PutNextRectangle(textImage.Size);
                TextRenderer.DrawText(
                    graphics, 
                    textImage.Text, 
                    textImage.Font,
                    rectangle.Location, 
                    textImage.Color, 
                    flags
                    );
            }

            return bitmap;
        }        
    }
}
