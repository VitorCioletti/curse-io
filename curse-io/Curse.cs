namespace Curse_io
{
    using Enum;
    using System.Collections.Generic;
    using System.Linq;
    using WordList;

    public static class Curse
    {
        private static object _object = new object();

        private static Languages _languages = Languages.English;

        public static string Clean(string text)
        {
            lock (_object)
            {
                var lista = List.English.Split(',');

                foreach (var word in lista)
                    text = text.Replace(word, new string('*', word.Count()));

                return text;
            }
        }

        public static Languages[] SetLanguage(params Languages[] languages)
        {
            languages.Select(lang => _languages = lang | _languages);

            return languages;
        }

        public static IEnumerable<string> AddNewWords(IEnumerable<string> newWords)
        {
            return newWords;
        }

        public static string AddNewWord(string newWord)
        {
            return newWord;
        }

        public static IEnumerable<string> RemoveWords(IEnumerable<string> wordsToRemove)
        {
            return wordsToRemove;
        }

        public static string RemoveWord(string wordToRemove)
        {
            return wordToRemove;
        }
    }
}
