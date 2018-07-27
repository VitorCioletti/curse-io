namespace CurseIO.Data
{
    using Enum;
    using System.Collections.Generic;

    internal static class Words
    {
        internal static IEnumerable<string> Get(Language languages) => FilterWordsByLanguage(languages);

        private static IEnumerable<string> FilterWordsByLanguage(Language language)
        {
            var cursedWords = new List<string>();

            switch (language)
            {
                case Language.English:
                    cursedWords.AddRange(WordList.English.SplitBySpace());
                    break;
                case Language.Italian:
                    cursedWords.AddRange(WordList.Italian.SplitBySpace());
                    break;
                case Language.Spanish:
                    cursedWords.AddRange(WordList.Spanish.SplitBySpace());
                    break;
                case Language.French:
                    cursedWords.AddRange(WordList.French.SplitBySpace());
                    break;
                case Language.German:
                    cursedWords.AddRange(WordList.German.SplitBySpace());
                    break;
                default:
                    break;
            }

            return cursedWords;
        }

        private static IEnumerable<string> SplitBySpace(this string words) => words.Split('\n');
    }
}
