using System.Collections.Generic;

namespace TagsCloudVisualization
{
    public interface IAnalysator
    {
        Dictionary<string, double> GetWeights(IReadOnlyCollection<string> words);
    }
}
