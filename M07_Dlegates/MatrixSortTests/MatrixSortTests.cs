namespace M07_DelegatesTests
{
    using M07_Delegates;
    using NUnit.Framework;

    [TestFixture]
    public class MatrixSortTests
    {
        [Test]
        public void SotrMarixTest_SumAscending_SortedMatrix()
        {
            int[,] matrix =
            {
                { 1, 2, 3 },
                { 3, 4, 5 },
                { -5, -6, -7 },
            };

            int[,] sortedMatrix =
             {
                { -5, -6, -7 },
                { 1, 2, 3 },
                { 3, 4, 5 },
             };

            Assert.AreEqual(matrix.SortMatrix(MatrixSort.SortBySumStratagy, true), sortedMatrix);
        }

        [Test]
        public void SotrMarixTest_SumDecending_SortedMatrix()
        {
            int[,] matrix =
            {
                { 1, 2, 3 },
                { -3, -4, -5 },
                { 5, 6, 7 },
            };

            int[,] sortedMatrix =
             {
                { 5, 6, 7 },
                { 1, 2, 3 },
                { -3, -4, -5 }
             };

            Assert.AreEqual(matrix.SortMatrix(MatrixSort.SortBySumStratagy, false), sortedMatrix);
        }

        [Test]
        public void SotrMarixTest_MaxAscending_SortedMatrix()
        {
            int[,] matrix =
            {
                { 3, 0, 3 },
                { 0, 2, 0 },
                { -1, 0, 1 },
            };

            int[,] sortedMatrix =
             {
                { -1, 0, 1 },
                { 0, 2, 0 },
                { 3, 0, 3 },
             };

            Assert.AreEqual(matrix.SortMatrix(MatrixSort.SortByMaxStratagy, true), sortedMatrix);
        }

        [Test]
        public void SotrMarixTest_MaxDecending_SortedMatrix()
        {
            int[,] matrix =
            {
                { 0, 0, -1 },
                { 0, 0, 0 },
                { 2, 2, 0 },
            };

            int[,] sortedMatrix =
             {
                { 2, 2, 0 },
                { 0, 0, 0 },
                { 0, 0, -1 }
             };

            Assert.AreEqual(matrix.SortMatrix(MatrixSort.SortByMaxStratagy, false), sortedMatrix);
        }
    }
}