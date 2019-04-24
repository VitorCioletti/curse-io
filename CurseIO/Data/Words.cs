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
                    curseWords.AddRange(WordList.English);
                    break;
                case Language.Italian:
                    curseWords.AddRange(WordList.Italian);
                    break;
                case Language.Spanish:
                    curseWords.AddRange(WordList.Spanish);
                    break;
                case Language.French:
                    curseWords.AddRange(WordList.French);
                    break;
                case Language.German:
                    curseWords.AddRange(WordList.German);
                    break;
                default:
                    break;
            }

            return curseWords;
        }
    }
}
