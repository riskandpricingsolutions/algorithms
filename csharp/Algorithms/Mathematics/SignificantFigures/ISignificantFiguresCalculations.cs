namespace RiskAndPricingSolutions.Algorithms.Mathematics.SignificantFigures
{
    public interface ISignificantFiguresCalculations
    {
        double RoundToNSignificantFigures(double arg, int n);

        bool AreEqualToNSignificantFifures(double x1, double x2, int n);
    }
}
