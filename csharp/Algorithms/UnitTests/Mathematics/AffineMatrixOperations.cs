using System;
using NUnit.Framework;
using RiskAndPricingSolutions.Algorithms.Mathematics.Matrices;
using static System.Console;

namespace RiskAndPricingSolutions.Algorithms.UnitTests.Mathematics
{
    [TestFixture]  
    public class AffineMatrixOperations
    {
        [Test]
        public void Translate()
        {
            // Define the translation amounts
            int dx = 2, dy = 2;

            // Setup the affince translation matrix
            var t = new Matrix
            {
                {1,0,dx },
                {0,1,dy },
                {0,0,1 }
            };

            // Translate the point
            Point translatedPoint = t * new Point(3, 3);
            Assert.AreEqual(new Point(5,5),translatedPoint );
        }

        [Test]
        public void Scale()
        {
            // Define the scale (multiplicative) amounts
            int w = 3, h = 2;

            // Setup the affince translation matrix
            var t = new Matrix
            {
                {w,0,0 },
                {0,h,0 },
                {0,0,1 }
            };

            // Scale the point
            Point scaledPoint = t * new Point(3, 3);
            Assert.AreEqual(new Point(9, 6), scaledPoint);
        }

        [Test]
        public void Rotate()
        {
            // Define the rotation in radians
            double theta = Math.PI / 2.0;
            double cosTheta = Math.Cos(theta);
            double sinTheta = Math.Sin(theta);


            // Setup the rotation translation matrix
            var r = new Matrix
            {
                {cosTheta,-sinTheta },
                {sinTheta,cosTheta,0 },
                {0,0,1 }
            };

            //// Scale the point
            Point scaledPoint = r * new Point(3, 3);
            //Assert.AreEqual(new Point(9, 6), scaledPoint);
        }
    }
}
