using NUnit.Framework;

namespace M03_Strings.Tests
{
    [TestFixture]
    internal class ReverseWordsTests
    {
        [TestCase("Скоро новый год", "год новый Скоро")]
        [TestCase("Скоро", "Скоро")]
        [TestCase("", "")]
        public void ReverseWordsTests_Strings_RevetseString(string first, string excepted)
        {
            Assert.That(ReverseWords.DoIt(first), Is.EqualTo(excepted));
        }
    }
}