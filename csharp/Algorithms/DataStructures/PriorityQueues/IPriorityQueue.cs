
using System.Xml.Schema;

namespace RiskAndPricingSolutions.Algorithms.DataStructures.PriorityQueues
{
    public enum QueueMode
    {
        Max,
        Min
    };

    public interface IPriorityQueue<TK>
    {
        /// <summary>
        /// Insert the key into the queue
        /// </summary>
        /// <param name="key"></param>
        void Insert(TK key);

        /// <summary>
        /// Return the highest/lowest value
        /// </summary>
        TK Get { get; }

        /// <summary>
        /// Delete and return the highest/lowest key
        /// </summary>
        /// <returns></returns>
        TK Delete();

        // The number of elements
        int Count { get; }
    }
}
