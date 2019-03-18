using System.Linq;
using YandexMystem.Wrapper.Enums;
using YandexMystem.Wrapper.Models;

namespace TagsCloudVisualization
{
    public class Word
    {
        public readonly GramPartsEnum? GramPart;
        public readonly string InitialForm;
        public readonly string Text;

        public Word(string text)
        {
            Text = text;
        }

        public Word(string text, string initialForm, GramPartsEnum gramPart)
        {
            GramPart = gramPart;
            InitialForm = initialForm;
            Text = text;
        }


        public Word(WordModel wordModel)
        {
            var lexems = wordModel.Lexems;
            if (lexems.Count != 0)
            {
                InitialForm = lexems.First().Lexeme;
                GramPart = lexems.First().GramPart;
            }
            Text = wordModel.ToString();
        }

        public override int GetHashCode()
        {
            return Text.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Word)) return false;
            var word = obj as Word;
            return word.Text == Text;
        }
    }
}
