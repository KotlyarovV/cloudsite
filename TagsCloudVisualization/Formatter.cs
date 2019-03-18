namespace TagsCloudVisualization
{
    public class Formatter : IFormatter
    {
        public string GetOriginal(Word word)
        {
            return word.InitialForm.ToLower();
        }
    }
}
