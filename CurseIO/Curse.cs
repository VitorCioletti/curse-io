namespace CurseIO
{
    using Data;
    using Enum;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class Curse
    {
        public Language Language = Language.English;

        private List<string> _curseWords;

        private Dictionary<string, int> _curseRemoved;

        private char _curseChar = '*';

        public Curse()
        {
            SetCurseWords();
            _curseRemoved = new Dictionary<string, int>();
        }

        public string Clear(string text)
        {
            _curseWords.ForEach(curseWord => text = ReplaceCurse(text, curseWord));

            return text;
        }

        public string Clear(string text, out IDictionary<string, int> curseCleanedList)
        {
            _curseRemoved.Clear();

            var cleanedText = Clear(text);
            curseCleanedList = new Dictionary<string, int>(_curseRemoved);

            return cleanedText;
        }

        public Task<string> ClearAsync(string text) => Task.Run(() => Clear(text));

        public Language SetLanguage(Language language)
        {
            Language = language;

            SetCurseWords();

            return language;
        }

        public IEnumerable<string> GetCurrentDictionary() => _curseWords;

        public IEnumerable<string> AddNewWords(IEnumerable<string> newWords) => 
            newWords.Select(word => AddNewWord(word)).ToList();
        
        public string AddNewWord(string newWord)
        {
            _curseWords.Add(newWord);

            return newWord;
        }

        public IEnumerable<string> RemoveWords(IEnumerable<string> wordsToRemove)
        {
            wordsToRemove.ToList().ForEach(word => RemoveWord(word));

            return wordsToRemove;
        }

        public string RemoveWord(string wordToRemove)
        {
            _curseWords.Remove(wordToRemove);

            return wordToRemove;
        }

        private void SetCurseWords() => _curseWords = Words.Get(Language).ToList();

        private string ReplaceCurse(string text, string curseWord)
        {
            var patternToMatch = $@"\b{curseWord}\b";
            var curseCounter = Regex.Matches(text, patternToMatch).Count;

            if (curseCounter >= 1)
                _curseRemoved.Add(curseWord, curseCounter);

            return Regex.Replace(text, patternToMatch, new string(_curseChar, curseWord.Count()), RegexOptions.IgnoreCase);
        }
    }
}
