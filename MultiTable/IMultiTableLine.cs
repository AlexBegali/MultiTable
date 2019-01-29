using System.Collections.Generic;

namespace MultiTable
{
    public interface IMultiTableLine<TKey, TValue> : IEnumerable<TValue>, IEnumerator<TValue>
    {
        TKey Key { get; }
    }
}
