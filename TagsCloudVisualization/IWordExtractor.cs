using System.Collections.Generic;

namespace TagsCloudVisualization
{
    public interface IWordExtractor
    {
        IEnumerable<Word> ExtractWords(string text);
    }
}
