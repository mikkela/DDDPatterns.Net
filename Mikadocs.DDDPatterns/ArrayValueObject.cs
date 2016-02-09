using System.Collections;
using System.Linq;

namespace Mikadocs.DDDPatterns
{
    public class ArrayValueObject<T> : ValueObject<T[]>, IEnumerable
    {
        public ArrayValueObject(T[] value1) : base(CopyArray(value1))
        {
        }

        protected override bool Validate(T[] value)
        {
            return value != null;
        }

        public IEnumerator GetEnumerator()
        {
            return Value1.GetEnumerator();
        }

        public override bool Equals(ValueObject<T[]> other)
        {
            if (other.Value1.Length != Value1.Length)
                return false;

            return !Value1.Where((t, i) => !t.Equals(other.Value1[i])).Any();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Value1.Aggregate(342, (current, element) => current*31 + element.GetHashCode());
            }
        }

        private static T[] CopyArray(T[] value1)
        {
            if (value1 == null)
                return null;
            var result = new T[value1.Length];
            for (var i = 0; i < value1.Length; i++)
            {
                result[i] = value1[i];
            }

            return result;
        }
    }
}