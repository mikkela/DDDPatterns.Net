using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikadocs.DDDPatterns
{
    public class EnumerableValueObject<T> : ValueObject<IEnumerable<T>>, IEnumerable<T>
    {
        public EnumerableValueObject(IEnumerable<T> value1) : base(value1.ToList())
        {
        }

        protected override bool Validate(IEnumerable<T> value)
        {
            return value != null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Value1.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override bool Equals(ValueObject<IEnumerable<T>> other)
        {
            return Value1.SequenceEqual(other.Value1);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Value1.Aggregate(19, (current, v) => current * 31 + v.GetHashCode());
            }
        }
    }
}
