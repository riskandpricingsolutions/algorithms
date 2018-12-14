namespace RiskAndPricingSolutions.Algorithms.DataStructures.Reverse
{
    public class SimpleReverser : IReverser
    {
        public T[] Reverse<T>(T[] arr)
        {
            T[] rev = new T[arr.Length];

            for (int i = 0; i < arr.Length; i++)
                rev[i] = arr[arr.Length - 1 - i];

            return rev;
        }

        public void ReverseInPlace<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                T temp = arr[i];
                arr[i] = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = temp;
            }
        }
    }
}
