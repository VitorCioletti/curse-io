namespace CurseIO
{
    using Data;
    using Enum;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public static class Curse
    {
        private static Language _language = Language.English;

        private static List<string> _curseWords;

        private static int _curseRemoved;

        private static char _curseChar = '*';

        static Curse()
        {
            SetCurseWords();
        }

        public static string Clear(string text)
        {
            _curseWords.ForEach(curseWord => text = text.ReplaceCurse(curseWord));

            return text;
        }

        public static string Clear(string text, out int curseCounter)
        {
            var cleanedText = Clear(text);
            curseCounter = _curseRemoved;

            _curseRemoved = 0;

            return cleanedText;
        }

        public static Task<string> ClearAsync(string text) => Task.Run(() => Clear(text));

        public static Language SetLanguage(Language language)
        {
            _language = language;

            SetCurseWords();

            return language;
        }

        public static IEnumerable<string> AddNewWords(IEnumerable<string> newWords) => 
            newWords.Select(word => AddNewWord(word)).ToList();
        
        public static string AddNewWord(string newWord)
        {
            _curseWords.Add(newWord);

            return newWord;
        }

        public static IEnumerable<string> RemoveWords(IEnumerable<string> wordsToRemove)
        {
            wordsToRemove.ToList().ForEach(word => RemoveWord(word));

            return wordsToRemove;
        }

        public static string RemoveWord(string wordToRemove)
        {
            _curseWords.Remove(wordToRemove);

            return wordToRemove;
        }

        private static void SetCurseWords() => _curseWords = Words.Get(_language).ToList();

        private static string ReplaceCurse(this string text, string curseWord)
        {
            var patternToMatch = $@"\b{curseWord}\b";

            _curseRemoved += Regex.Matches(text, patternToMatch).Count;

            return Regex.Replace(text, patternToMatch, new string(_curseChar, curseWord.Count()), RegexOptions.IgnoreCase);
        }
    }
}
