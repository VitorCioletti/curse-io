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
        public void ShouldClearTextFromCursed()
        {
            // Arrange
            var textToBeCleaned = "The quick brown fox jumps over the fuck dog";
            var resultedText = "The quick brown fox jumps over the **** dog";

            // Act
            var cleaned = Curse.Clear(textToBeCleaned);

            // Assert
            Assert.AreEqual(resultedText, cleaned);
        }

        [TestMethod]
        public void ShouldCountCleanedWords()
        {
            // Arrange
            var textToBeCleaned = "The fuck brown fox jumps over the fuck dog";
            IDictionary<string, int> cleanedWords;

            // Act
            Curse.Clear(textToBeCleaned, out cleanedWords);

            // Assert
            Assert.AreEqual(2, cleanedWords["fuck"]);
        }

        [TestMethod]
        public void ShouldAddNewWordToDictionary()
        {
            // Arrange
            var word = "OkieDokie";

            // Act
            Curse.AddNewWord(word);

            // Assert
            Assert.IsTrue(Curse.GetCurrentDictionary().ToList().Contains(word));
        }

        [TestMethod]
        public void ShouldRemoveWordFromDictionary()
        {
            // Arrange
            var word = "shit";
            
            // Act
            Curse.RemoveWord(word);

            // Assert
            Assert.IsFalse(Curse.GetCurrentDictionary().Contains(word));
        }
    }
}
