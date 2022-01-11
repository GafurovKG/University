using MyGenetics;
using NUnit.Framework;

namespace MyGeneticsTests
{
    [TestFixture]
    public class MyBinarySearchTests
    {
        [Test]
        public void BinarySearch_intOddArray_intValue__valuesPositions()
        {
            int[] array = { -7, -6, -3, 0, 1, 5, 8, 9, 13 };

            for (int i = 0; i < array.Length; i++)
            {
                if (MyBinarySearch.BinarySearch(array, array[i]) != i)
                {
                    Assert.IsTrue(false);
                }
            }

            Assert.IsTrue(true);
        }

        [Test]
        public void BinarySearch_intEvenArray_intValue__valuesPositions()
        {
            int[] array = { -10, -7, -6, -3, 0, 1, 5, 8, 9, 13 };

            for (int i = 0; i < array.Length; i++)
            {
                if (MyBinarySearch.BinarySearch(array, array[i]) != i)
                {
                    Assert.IsTrue(false);
                }
            }

            Assert.IsTrue(true);
        }

        [Test]
        public void BinarySearch_StringArray_valuesPositions()
        {
            string[] array = { "apple", "banana", "cocount", "grape", "mango", "orange" };

            for (int i = 0; i < array.Length; i++)
            {
                if (MyBinarySearch.BinarySearch(array, array[i]) != i)
                {
                    Assert.IsTrue(false);
                }
            }

            Assert.IsTrue(true);
        }
    }
}