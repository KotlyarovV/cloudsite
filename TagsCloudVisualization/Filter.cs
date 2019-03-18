using System.Linq;
using YandexMystem.Wrapper.Enums;


namespace TagsCloudVisualization
{
    public class Filter : IFilter
    {
        private readonly GramPartsEnum[] _excludedGramParts;

        public Filter(GramPartsEnum[] excludedGramParts)
        {
            _excludedGramParts = excludedGramParts;
        }

        public bool IsNecessaryPartOfSpeech(Word word)
        {
            if (word.InitialForm == null || word.GramPart == null) return false;
            return !_excludedGramParts.Contains(word.GramPart.GetValueOrDefault());
        }
    }
}
