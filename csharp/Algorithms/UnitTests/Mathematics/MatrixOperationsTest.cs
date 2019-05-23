using NUnit.Framework;
using System;
using System.Linq;
using RiskAndPricingSolutions.Algorithms.Mathematics.Matrices;
using static System.Console;

namespace RiskAndPricingSolutions.Algorithms.UnitTests.Mathematics
{
    [TestFixture]
    public class MatrixOperationsTest
    {
        [Test]
        public void Translation()
        {
            var t = new double[,]
            {
                {0,1,0},
                {-1,0,0}

            };

            Point[] p = {
                new Point(0,0), 
                new Point(5,0), 
                new Point(5,5), 
                new Point(0,5) 
            };

            Point[] pp = p.Select(point =>
            {
                var temp = MatrixOperations.MatrixMultiply(new double[,] {{point.X, point.Y}}, t);
                return new Point((int) temp[0, 0], (int) temp[0, 1]);
            }).ToArray();
        }
    }
}   