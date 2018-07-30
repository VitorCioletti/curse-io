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
        private Language _language = Language.English;

        private List<string> _curseWords;

        private Dictionary<string, int> _curseRemoved;

        private char _curseChar = '*';

        public Curse()
        {
            SetCurseWords();
            _curseRemoved = new Dictionary<string, int>();
        }


        /// <summary>
        /// Creates a new Curse object and sets its current language
        /// </summary>
        /// <param name="language">Language of the curse word dictionary</param>
        public Curse(Language language)
        {
            SetCurseWords();
            _curseRemoved = new Dictionary<string, int>();

            _language = language;
        }

        /// <summary>
        /// Cleanse the given string, replacing its bad words to '*' character
        /// </summary>
        /// <param name="text">Text to be cleansed</param>
        public string Cleanse(string text)
        {
            _curseWords.ForEach(curseWord => text = ReplaceCurse(text, curseWord));

            return text;
        }

        /// <summary>
        /// Cleanse the given string, replacing its bad words to '*' character
        /// </summary>
        /// <param name="text">Text to be cleansed</param>
        /// /// <param name="curseCleansedList">Key: Bad word removed; Value: How many times the word appeared in the given string</param>
        public string Cleanse(string text, out IDictionary<string, int> curseCleansedList)
        {
            _curseRemoved.Clear();

            var cleanedText = Cleanse(text);
            curseCleansedList = new Dictionary<string, int>(_curseRemoved);

            return cleanedText;
        }

        /// <summary>
        /// Cleanse the given string, replacing its bad words to '*' character
        /// </summary>
        /// <param name="text">Text to be cleansed</param>
        public Task<string> CleanseAsync(string text) => Task.Run(() => Cleanse(text));

        /// <summary>
        /// Set the current language
        /// </summary>
        /// <param name="language">The desired language to be set</param>
        public Language SetLanguage(Language language)
        {
            _language = language;

            SetCurseWords();

            return language;
        }

        /// <summary>
        /// Gets the current language
        /// </summary>
        public Language GetCurrentLanguage() => _language;

        /// <summary>
        /// Gets the current curse word dictionary
        /// </summary>
        public IEnumerable<string> GetCurrentDictionary() => _curseWords;

        /// <summary>
        /// Add words to the current curse word dictionary
        /// </summary>
        /// <param name="newWords">New words to be added</param>
        public IEnumerable<string> AddNewWords(IEnumerable<string> newWords) => 
            newWords.Select(word => AddNewWord(word)).ToList();

        /// <summary>
        /// Add a single word to the current curse word dictionary
        /// </summary>
        /// <param name="newWord">Word to be added</param>
        public string AddNewWord(string newWord)
        {
            _curseWords.Add(newWord);

            return newWord;
        }

        /// <summary>
        /// Remove words to the current curse word dictionary
        /// </summary>
        /// <param name="wordsToRemove">Words to be removed</param>
        public IEnumerable<string> RemoveWords(IEnumerable<string> wordsToRemove)
        {
            wordsToRemove.ToList().ForEach(word => RemoveWord(word));

            return wordsToRemove;
        }

        /// <summary>
        /// Remove a single word to the current curse word dictionary
        /// </summary>
        /// <param name="wordsToRemove">Word to be removed</param>
        public string RemoveWord(string wordToRemove)
        {
            _curseWords.Remove(wordToRemove);

            return wordToRemove;
        }

        private void SetCurseWords() => _curseWords = Words.Get(_language).ToList();

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
