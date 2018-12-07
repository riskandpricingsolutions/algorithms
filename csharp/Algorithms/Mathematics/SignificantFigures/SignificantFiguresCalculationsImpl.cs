using System;

namespace RiskAndPricingSolutions.Algorithms.Mathematics.SignificantFigures
{
    public class SignificantFiguresCalculationsImpl : ISignificantFiguresCalculations
    {
      public double RoundToNSignificantFigures(double x, int n)
        {
            if (Math.Abs(x) < TOL)
                return 0.0;

            // Any decimal number x can be written as 
            // Mantissa x 10^exponent where the mantissa is a number 
            // greater than zero and less than 10. We can obtain the 
            // the mantissa and exponent by taking the logarithm base 10
            // and splitting the result into whole and fractional parts
            // As we use logarithms we work on the absolute value of x
            double abs = Math.Abs(x);
            double log = Math.Log10(abs);
            double exp = Math.Floor(log);
            double mant = log - exp;

            // Now if we multiply our original number by -exp we get 
            // a number of the form 1.abc... If we were to round this we
            // would get a number with 1 significant figures. To get n
            // significant figures we need to multiple by n-1 - exp
            double preRound = x * Math.Pow(10, n - 1 - exp);

            double rounded = Math.Round(preRound);

            // Now we have a rounded number we need to put back the
            // magnitude 
            double y = rounded * Math.Pow(10, exp + 1 - n);

            return y;
        }

        public bool AreEqualToNSignificantFifures(double x1, double x2, int n)
        {
            double y1 = RoundToNSignificantFigures(x1, n);
            double y2 = RoundToNSignificantFigures(x2, n);

            return Math.Abs(y1 - y2) < TOL;
        }

        // Assume anything less than this is numerical noise
        private double TOL = 0.0000000000001;
    }
}
