namespace CurseIO
{
    using Data;
    using Enum;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System;

    /// <summary>
    /// Class to cleanse strings from bad words.
    /// </summary>
    public class Curse
    {
        private Language _language = Language.English;

        private List<string> _curseWords;

        private Dictionary<string, int> _curseRemoved;

        private char _curseChar = '*';

        /// <summary>
        /// Creates a new instance of Curse class.
        /// </summary>
        public Curse()
        {
            SetCurseWords();
            _curseRemoved = new Dictionary<string, int>();
        }

        /// <summary>
        /// Creates a new instance of Curse class.
        /// </summary>
        /// <param name="language">Language of the curse word dictionary.</param>
        public Curse(Language language)
        {
            SetCurseWords();
            _curseRemoved = new Dictionary<string, int>();

            _language = language;
        }

        /// <summary>
        /// Cleanse the given string, replacing its bad words to '*' character.
        /// </summary>
        /// <param name="text">Text to be cleansed.</param>
        public string Cleanse(string text)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
                return text;

            foreach (var curseWord in _curseWords)
                text = ReplaceCurse(text, curseWord);

            return text;
        }

        /// <summary>
        /// Cleanse the given string, replacing its bad words to '*' character.
        /// </summary>
        /// <param name="text">Text to be cleansed.</param>
        /// /// <param name="curseCleansedList">Key: Bad word removed; Value: How many times the word appeared in the given string.</param>
        public string Cleanse(string text, out IDictionary<string, int> curseCleansedList)
        {
            curseCleansedList = new Dictionary<string, int>();

            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
                return text;

            _curseRemoved.Clear();

            var cleanedText = Cleanse(text);
            curseCleansedList = _curseRemoved;

            return cleanedText;
        }

        /// <summary>
        /// Cleanse the given string, replacing its bad words to '*' character.
        /// </summary>
        /// <param name="text">Text to be cleansed.</param>
        /// <param name="errorCallback">Callback to execute in case of failure.</param>
        public async Task<string> CleanseAsync(string text, Action<Exception> errorCallback = null)
        {
            return await Task.Run(() => Cleanse(text)).ContinueWith<string>(
                e => 
                {
                    errorCallback?.Invoke(e.Exception);

                    return null;
                },
                TaskContinuationOptions.OnlyOnFaulted
            );
        }

        /// <summary>
        /// Set the current curse char.
        /// </summary>
        /// <param name="newChar">The new curse char.</param>
        public char SetCurseChar(char newChar) => _curseChar = newChar;

        /// <summary>
        /// Set the current language.
        /// </summary>
        /// <param name="language">The desired language to be set.</param>
        public Language SetLanguage(Language language)
        {
            _language = language;

            SetCurseWords();

            return language;
        }

        /// <summary>
        /// Gets the current language.
        /// </summary>
        public Language GetCurrentLanguage() => _language;

        /// <summary>
        /// Gets the current curse word dictionary.
        /// </summary>
        public IEnumerable<string> GetCurrentDictionary() => _curseWords;

        /// <summary>
        /// Add words to the current curse word dictionary.
        /// </summary>
        /// <param name="newWords">New words to be added.</param>
        public IEnumerable<string> AddNewWords(IEnumerable<string> newWords) => 
            newWords.Select(word => AddNewWord(word)).ToList();

        /// <summary>
        /// Add a single word to the current curse word dictionary.
        /// </summary>
        /// <param name="newWord">Word to be added.</param>
        public string AddNewWord(string newWord)
        {
            _curseWords.Add(newWord);

            return newWord;
        }

        /// <summary>
        /// Remove words to the current curse word dictionary.
        /// </summary>
        /// <param name="wordsToRemove">Words to be removed.</param>
        public IEnumerable<string> RemoveWords(IEnumerable<string> wordsToRemove)
        {
            foreach (var word in wordsToRemove)
                RemoveWord(word);

            return wordsToRemove;
        }

        /// <summary>
        /// Remove a single word to the current curse word dictionary.
        /// </summary>
        /// <param name="wordToRemove">Word to be removed.</param>
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

            return Regex.Replace(
                text, 
                patternToMatch, 
                new string(_curseChar, curseWord.Length),
                RegexOptions.IgnoreCase
            );
        }
    }
}
