namespace RiskAndPricingSolutions.Algorithms.Mathematics.Rounding
{
    public interface IRounding
    {
        double RoundNearest(double x, double precision);

        double RoundDown(double x, double precision);

        double RoundUp(double x, double precision);
    }
}
