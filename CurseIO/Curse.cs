namespace CurseIO
{
    using Data;
    using Enum;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class Curse
    {
        private static Language _languages = Language.English;

        private static int _curseRemoved;

        private static char _curseChar = '*';

        public static string Clear(string text)
        {
            Words.Get(_languages)
                 .Select(curseWord => text = text.ReplaceCursed(curseWord))
                 .ToList();

            return text;
        }

        public static string Clear(string text, out int curseCounter)
        {
            var cleanedText = Clear(text);
            curseCounter = _curseRemoved;

            _curseRemoved = 0;

            return cleanedText;
        }

        public static Language[] SetLanguage(params Language[] languages)
        {
            languages.Select(lang => _languages = lang | _languages).ToList();

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

        private static string ReplaceCursed(this string text, string curseWord)
        {
            var patternToMatch = $@"\b{curseWord}\b";

            _curseRemoved += Regex.Matches(text, patternToMatch).Count;

            return Regex.Replace(text, patternToMatch, new string(_curseChar, curseWord.Count()), RegexOptions.IgnoreCase);
        }
    }
}
