using NUnit.Framework;

namespace M03_Strings.Tests
{
    [TestFixture]
    internal class LongSumTests
    {
        [TestCase ("123456789123456789", "123456789123456", "123580245912580245")]
        [TestCase ("12", "", "12")]
        [TestCase("", "", "")]
        public void LongSumDoIt_TwoStrings_SumString(string first, string second, string excepted)
        {
            Assert.That(LongSum.DoIt(first, second), Is.EqualTo(excepted));
        }

        [TestCase(123456789123456789l, 123456789123456l)]
        public void LongSumDoIt_TwoLongs_SumLong(long first, long second)
        {
            long res = first + second;
            Assert.That(LongSum.DoIt(first.ToString(), second.ToString()), Is.EqualTo(res.ToString()));
        }
    }
}