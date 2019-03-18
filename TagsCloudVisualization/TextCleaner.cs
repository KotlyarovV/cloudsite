namespace TagsCloudVisualization
{
    public class TextCleaner : ITextCleaner
    {
        private char[] replacedChars;
        public TextCleaner(char[] replacedChars)
        {
            this.replacedChars = replacedChars;
        }
        public string RemoveSigns(string text)
        {
            foreach (var replacedChar in replacedChars)
            {
                text = text.Replace(replacedChar, ' ');
            }
            return text;
        }
    }
}
