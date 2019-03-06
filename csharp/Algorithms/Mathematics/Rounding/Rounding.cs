using System;

namespace RiskAndPricingSolutions.Algorithms.Mathematics.Rounding
{
    public class Rounding : IRounding
    {
        public double RoundNearest(double x, double precision) => Math.Round(x / precision) * precision;

        public double RoundDown(double x, double precision) => Math.Floor(x / precision) * precision;

        public double RoundUp(double x, double precision) => Math.Ceiling(x / precision) * precision;
    }
}
