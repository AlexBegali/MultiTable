using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTable
{
    public class MultiTable<TFirstKey, TSecondKey, TValue>
        where TFirstKey : IComparable, IConvertible, IFormattable
        where TSecondKey : IComparable, IConvertible, IFormattable
    {
        private Type FirstKeyType;
        private Type SecondKeyType;

        private TFirstKey[] FirstKeyValues;
        private TSecondKey[] SecondKeyValues;

        private TValue[] Values;

        //private Dictionary<TFirstKey, List<FirstKeyLine>> AvailableFirstKeysEnumerables = new Dictionary<TFirstKey, List<FirstKeyLine>>();
        //private Dictionary<TSecondKey, List<SecondKeyLine>> AvailableSecondKeysEnumerables = new Dictionary<TSecondKey, List<SecondKeyLine>>();

        private Dictionary<TFirstKey, int> FirstKeyToIndex = new Dictionary<TFirstKey, int>();
        private Dictionary<TSecondKey, int> SecondKeyToIndex = new Dictionary<TSecondKey, int>();

        private Dictionary<int, TFirstKey> IndexToFirstKey = new Dictionary<int, TFirstKey>();
        private Dictionary<int, TSecondKey> IndexToSecondKey = new Dictionary<int, TSecondKey>();

        public MultiTable()
        {
            FirstKeyType = typeof(TFirstKey);
            SecondKeyType = typeof(TSecondKey);

            if (FirstKeyType.IsEnum == false || SecondKeyType.IsEnum == false) throw new UnsupportedTypeException("Only enum types are allowed as a parameters");

            FirstKeyValues = (TFirstKey[])Enum.GetValues(FirstKeyType);
            SecondKeyValues = (TSecondKey[])Enum.GetValues(SecondKeyType);

            if (FirstKeyValues.Length == 0 || SecondKeyValues.Length == 0) throw new EmptyEnumException("One of enums contain no values");

            InitializeArray();
        }
        
        protected void InitializeArray()
        {
            Values = new TValue[FirstKeyValues.Length * SecondKeyValues.Length];

            int index = -1;

            foreach (TFirstKey key in FirstKeyValues)
            {
                //AvailableFirstKeysEnumerables.Add(key, new List<FirstKeyLine>());

                index = Array.FindIndex(FirstKeyValues, x => x.Equals(key));
                FirstKeyToIndex.Add(key, index);
                IndexToFirstKey.Add(index, key);
            }

            foreach (TSecondKey key in SecondKeyValues)
            {
                //AvailableSecondKeysEnumerables.Add(key, new List<SecondKeyLine>());

                index = Array.FindIndex(SecondKeyValues, x => x.Equals(key));
                SecondKeyToIndex.Add(key, index);
                IndexToSecondKey.Add(index, key);
            }
        }
    }

    public class MultiTable<TFirstKey, TSecondKey, TThirdKey, TValue> : MultiTable<TFirstKey, TSecondKey, TValue>
            where TFirstKey : IComparable, IConvertible, IFormattable
            where TSecondKey : IComparable, IConvertible, IFormattable
            where TThirdKey : IComparable, IConvertible, IFormattable
    {


        public MultiTable()
        {

        }
    }
}
