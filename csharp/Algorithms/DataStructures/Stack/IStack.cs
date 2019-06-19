
namespace RiskAndPricingSolutions.Algorithms.DataStructures.Stack
{
    public interface IStack<T>
    {
        void Push(T item);

        T Pop();

        long Count { get; }
    }
}
