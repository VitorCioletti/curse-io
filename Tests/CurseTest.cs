namespace Tests
{
    using CurseIO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class CurseTest
    {
        [TestMethod]
        public void ShouldClearTextFromCursed()
        {
            // Arrange
            var textToBeCleaned = "The quick brown fox jumps over the fuck dog";
            var resultedText = "The quick brown fox jumps over the **** dog";
            var curse = new Curse();

            // Act
            var cleaned = curse.Clear(textToBeCleaned);

            // Assert
            Assert.AreEqual(resultedText, cleaned);
        }

        [TestMethod]
        public void ShouldCountCleanedWords()
        {
            // Arrange
            var curse = new Curse();

            var textToBeCleaned = "The fuck brown fox jumps over the fuck dog";
            IDictionary<string, int> cleanedWords;

            // Act
            curse.Clear(textToBeCleaned, out cleanedWords);

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
    }
}
