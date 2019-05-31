namespace RiskAndPricingSolutions.Algorithms.Mathematics.Factorial
{
    public static class FactorialExtentions
    {
        public static long Factorial(this long n) => FactorialCalculator.FactorialIterative(n);

        private static readonly IFactorialCalculator FactorialCalculator = new FactorialCalculator();
    }
}
