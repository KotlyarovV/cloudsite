namespace TagsCloudVisualization
{
    public interface IFilter
    {
        bool IsNecessaryPartOfSpeech(Word word);
    }
}
