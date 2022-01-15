using MyGenetics;
using NUnit.Framework;

namespace MyGeneticsTests
{
    [TestFixture]
    public class CalculatorTests
    {
        [TestCase("5 1 2 + 4 * + 3 -", 14)]
        [TestCase("", 0)]
        [TestCase("555 5 / 111 -", 0)]
        public void PolishCalulate_RNP_Expression_Result(string expression, double result)
        {
            Assert.AreEqual(Calculator.PolishCalulate(expression), result);
        }
    }
}