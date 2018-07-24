namespace CurseIO.Data
{
    using Enum;
    using System.Collections.Generic;

    internal static class Words
    {
        internal static IEnumerable<string> Get(Language languages) => FilterWordsByLanguage(languages);

        private static IEnumerable<string> FilterWordsByLanguage(Language languages)
        {
            var cursedWords = new List<string>();

            if (languages.Equals(Language.English))
                cursedWords.AddRange(WordList.English.SplitBySpace());

            if(languages.Equals(Language.PortugueseBR))
                cursedWords.AddRange(WordList.English.SplitBySpace());

            return cursedWords;
        }

        private static IEnumerable<string> SplitBySpace(this string words) => words.Split('\n');
    }
}
