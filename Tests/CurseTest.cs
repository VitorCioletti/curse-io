namespace Tests
{
    using CurseIO;
    using CurseIO.Enum;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class CurseTest
    {
        [TestMethod]
        public void ShouldCleanseTextFromCursed()
        {
            // Arrange
            var textToBeCleaned = "The quick brown fox jumps over the fuck dog";
            var resultedText = "The quick brown fox jumps over the **** dog";
            var curse = new Curse();

            // Act
            var cleaned = curse.Cleanse(textToBeCleaned);

            // Assert
            Assert.AreEqual(resultedText, cleaned);
        }
        [TestMethod]
        public void ShouldNotCleanseTextFromCursed()
        {
            // Arrange
            var textToBeCleaned = "The quick brown fox jumps over thefuck dog";
            var curse = new Curse();

            // Act
            var cleansed = curse.Cleanse(textToBeCleaned);

            // Assert
            Assert.AreEqual(textToBeCleaned, cleansed);
        }


        [TestMethod]
        public void ShouldCountCleanedWords()
        {
            // Arrange
            var curse = new Curse();

            var textToBeCleansed = "The fuck brown fox jumps over the fuck dog";
            IDictionary<string, int> cleanedWords;

            // Act
            curse.Cleanse(textToBeCleansed, out cleanedWords);

            // Assert
            Assert.AreEqual(2, cleanedWords["fuck"]);
        }

        [TestMethod]
        public void ShouldAddNewWordToDictionary()
        {
            // Arrange
            var word = "OkieDokie";
            var curse = new Curse();

            // Act
            curse.AddNewWord(word);

            // Assert
            Assert.IsTrue(curse.GetCurrentDictionary().ToList().Contains(word));
        }

        [TestMethod]
        public void ShouldRemoveWordFromDictionary()
        {
            // Arrange
            var word = "shit";
            var curse = new Curse();

            // Act
            curse.RemoveWord(word);

            // Assert
            Assert.IsFalse(curse.GetCurrentDictionary().Contains(word));
        }

        [TestMethod]
        public void ShouldRemoveWordsFromDictionary()
        {
            // Arrange
            var curse = new Curse();
            var words = new List<string>() { "fuck", "wanky" };

            // Act
            curse.RemoveWords(words);
            var notRemoved = curse.GetCurrentDictionary().Any(e => words.Contains(e));

            // Assert
            Assert.IsFalse(notRemoved);
        }

        [TestMethod]
        public void ShouldAddNewCurseChar()
        {
            // Arrange
            var textToBeCleansed = "The fuck brown fox jumps over the fuck dog";
            var expectedText = "The ???? brown fox jumps over the ???? dog";

            var curse = new Curse();

            // Act
            curse.SetCurseChar('?');
            var cleansed = curse.Cleanse(textToBeCleansed);

            // Assert
            Assert.AreEqual(expectedText, cleansed);
        }

        [TestMethod]
        public void FrenchDictionaryWithNoEmptyLines()
        {
            // Arrange
            var curse = new Curse();

            curse.SetLanguage(Language.French);

            // Act
            var hasEmpty = curse.GetCurrentDictionary().Contains(string.Empty);

            // Assert
            Assert.IsFalse(hasEmpty);
        }

        [TestMethod]
        public void ItalianDictionaryWithNoEmptyLines()
        {
            // Arrange
            var curse = new Curse();

            curse.SetLanguage(Language.Italian);

            // Act
            var hasEmpty = curse.GetCurrentDictionary().Contains(string.Empty);

            // Assert
            Assert.IsFalse(hasEmpty);
        }

        [TestMethod]
        public void GermanDictionaryWithNoEmptyLines()
        {
            // Arrange
            var curse = new Curse();

            curse.SetLanguage(Language.German);

            // Act
            var hasEmpty = curse.GetCurrentDictionary().Contains(string.Empty);

            // Assert
            Assert.IsFalse(hasEmpty);
        }

        [TestMethod]
        public void SpanishDictionaryWithNoEmptyLines()
        {
            // Arrange
            var curse = new Curse();

            curse.SetLanguage(Language.Spanish);

            // Act
            var hasEmpty = curse.GetCurrentDictionary().Contains(string.Empty);

            // Assert
            Assert.IsFalse(hasEmpty);
        }
    }
}
