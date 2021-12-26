using NUnit.Framework;

namespace M03_Strings.Tests
{
    internal class WordsAverageLengthTests
    {
        [TestCase ("�������� ������, �� ������� ����������!", 6.6d)]
        [TestCase ("�������� ������ 2, � 2 ������� ����������!", 4.9d)]
        public void WALDoIt_TestString_AverageLength(string _string, double expected)
        {
            // Arrange

            // Act$Assert
            Assert.That(WordsAverageLength.DoIt(_string), Is.EqualTo(expected));
        }
    }
}