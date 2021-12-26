using NUnit.Framework;

namespace M03_Strings.Tests
{
    internal class WordsAverageLengthTests
    {
        [TestCase ("“естова€ строка, со знаками препинани€!", 6.6d)]
        [TestCase ("“естова€ строка 2, с 2 знаками препинани€!", 4.9d)]
        public void WALDoIt_TestString_AverageLength(string _string, double expected)
        {
            // Arrange

            // Act$Assert
            Assert.That(WordsAverageLength.DoIt(_string), Is.EqualTo(expected));
        }
    }
}