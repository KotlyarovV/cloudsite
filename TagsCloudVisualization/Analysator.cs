using System.Collections.Generic;
using System.Linq;

namespace TagsCloudVisualization
{    
    public class Analysator : IAnalysator
    {       
        public Dictionary<string, double> GetWeights(IReadOnlyCollection<string> words)
        {
            var count = words.Count;
            return words
                .GroupBy(word => word, (word, wordsSame) => new { Key = word, Count = wordsSame.Count()})
                .ToDictionary(pair => pair.Key, pair => pair.Count / (double) count);
        }
    }    
}
