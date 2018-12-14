namespace RiskAndPricingSolutions.Algorithms.DataStructures.Reverse
{
    public interface IReverser
    {
        T[] Reverse<T>(T[] arr);
        void ReverseInPlace<T>(T[] arr);
    }
}
