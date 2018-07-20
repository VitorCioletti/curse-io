namespace CurseIO.Data
{
    using Enum;
    using System.Collections.Generic;

    public static class Words
    {
        public static IEnumerable<string> Get(Language languages) => FilterLanguages(languages);

        private static IEnumerable<string> FilterLanguages(Language languages)
        {
            var cursedWords = new List<string>();

            if (languages.HasFlag(Language.English))
                cursedWords.AddRange(WordList.English.SplitBySpace());

            return cursedWords;
        }

        private static IEnumerable<string> SplitBySpace(this string words) => words.Split('\n');
    }
}
