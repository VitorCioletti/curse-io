namespace CurseIO.Data
{
    using Enum;
    using System.Collections.Generic;

    internal static class Words
    {
        internal static IEnumerable<string> Get(Language languages) => FilterWordsByLanguage(languages);

        private static IEnumerable<string> FilterWordsByLanguage(Language language)
        {
            var curseWords = new List<string>();

            switch (language)
            {
                case Language.English:
                    curseWords.AddRange(WordList.English.SplitBySpace());
                    break;
                case Language.Italian:
                    curseWords.AddRange(WordList.Italian.SplitBySpace());
                    break;
                case Language.Spanish:
                    curseWords.AddRange(WordList.Spanish.SplitBySpace());
                    break;
                case Language.French:
                    curseWords.AddRange(WordList.French.SplitBySpace());
                    break;
                case Language.German:
                    curseWords.AddRange(WordList.German.SplitBySpace());
                    break;
                default:
                    break;
            }

            return curseWords;
        }

        private static IEnumerable<string> SplitBySpace(this string words) =>
			words.Replace("\r", string.Empty).Split('\n');
    }
}
