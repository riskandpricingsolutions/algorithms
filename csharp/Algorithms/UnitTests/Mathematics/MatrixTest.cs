using NUnit.Framework;
using RiskAndPricingSolutions.Algorithms.Mathematics.Matrices;
using static System.Console;

namespace RiskAndPricingSolutions.Algorithms.UnitTests.Mathematics
{
    [TestFixture]
    public class MatrixTest
    {
        [Test]
        public void CollectionInitializationTest()
        {
            Matrix a = new Matrix()
            {
                {1,2,4 },
                {5,6,7 }
            };

            WriteLine(a);
        }

        [Test]
        public void RotateImage()
        {
            Matrix a = new Matrix(new double[,]
            {
                {0,1},
                {-1,0}
            });

            Matrix x00 = new Matrix(new double[] {0,0});
            Matrix x01 = new Matrix(new double[] {0,1});
            Matrix x11 = new Matrix(new double[] {1,1});

            var xp00 = x00* a;
            var xp01 = x01* a;
            var xp11 = x11* a;


        }


        [Test]
        public void MatrixMultiplicationTest()
        {
            Matrix a = new Matrix( new double[,]
            {
                {4,7,6},
                {2,3,1}
            });

            Matrix b = new Matrix(new double[,]
            {
                {8},
                {5},
                {9}
            });

            Assert.AreEqual(new Matrix(new double[,] { { 121, 40 } }), a*b);
        }

        [Test]
        public void TransposeTest()
        {
            Matrix A = new Matrix(new double[,]
            {
                {4,7,6},
                {2,3,1}
            });

            WriteLine(A.Transpose().ToString(1));
        }

        [Test]
        public void EqualityTest()
        {
            Assert.AreEqual(new Matrix(new double[,] {{1, 2}}), new Matrix(new double[,] {{1, 2}}));
        }
    }
}