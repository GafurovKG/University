using System.Collections.Generic;
using MyGenetics;
using NUnit.Framework;

namespace MyGeneticsTests
{
    [TestFixture]
    public class FibonachyGeneratorTests
    {
        [Test]
        public void GenerateFibonachy_TakeFibonachyList()
        {
            int countFibonachy = 10;
            var fib = FibonachyGenerator.GenerateFibonachy();
            var enumerator = fib.GetEnumerator();
            var fibList = new List<int>();
            for (int i = 0; i < countFibonachy; i++)
            {
                enumerator.MoveNext();
                fibList.Add(enumerator.Current);
            }

            int[] exceped = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };
            Assert.AreEqual(fibList.ToArray(), exceped);
        }
    }
}