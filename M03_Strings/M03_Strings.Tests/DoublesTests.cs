using NUnit.Framework;

namespace M03_Strings.Tests
{
    [TestFixture]
    internal class DoublesTests
    {
        [TestCase ("Первая строка", "П стр в", "ППеррввая ссттррока")]
        [TestCase ("", "", "")]
        [TestCase(" ", " ", " ")]
        [TestCase("Первая", " ", "Первая")]
        public void DoublesDoIt_TwoStrings_DoubledString(string first, string second, string excepted)
        {
            Assert.That(Doubles.DoIt(first, second), Is.EqualTo(excepted));
        }
    }
}