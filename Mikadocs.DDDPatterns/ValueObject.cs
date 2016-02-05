using System;
using System.Collections.Generic;

namespace Mikadocs.DDDPatterns
{
    [Serializable]
    public abstract class ValueObject
    {
    }

    [Serializable]
    public abstract class ValueObject<T1> : ValueObject, IEquatable<ValueObject<T1>>
    {
        protected ValueObject(T1 value1)
        {
            if (!Validate(value1))
            {
                throw new ArgumentException("One or more of the arguments are not valid");
            }
            Value1 = value1;
        }

        public T1 Value1 { get; }

        protected virtual bool Validate(T1 @value)
        {
            return true;
        }

        public virtual bool Equals(ValueObject<T1> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T1>.Default.Equals(Value1, other.Value1);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ValueObject<T1>)obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T1>.Default.GetHashCode(Value1);
        }
    }

    [Serializable]
    public abstract class ValueObject<T1, T2> : ValueObject, IEquatable<ValueObject<T1, T2>>
    {
        protected ValueObject(T1 value1, T2 value2)
        {
            if (!Validate(value1, value2))
            {
                throw new ArgumentException("One or more of the arguments are not valid");
            }

            Value1 = value1;
            Value2 = value2;
        }

        public T1 Value1 { get; }
        public T2 Value2 { get; }

        protected virtual bool Validate(T1 value1, T2 value2)
        {
            return true;
        }

        public virtual bool Equals(ValueObject<T1, T2> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T1>.Default.Equals(Value1, other.Value1) &&
                   EqualityComparer<T2>.Default.Equals(Value2, other.Value2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ValueObject<T1, T2>)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T1>.Default.GetHashCode(Value1) * 397) ^
                       EqualityComparer<T2>.Default.GetHashCode(Value2);
            }
        }
    }

    [Serializable]
    public abstract class ValueObject<T1, T2, T3> : ValueObject, IEquatable<ValueObject<T1, T2, T3>>
    {
        protected ValueObject(T1 value1, T2 value2, T3 value3)
        {
            if (!Validate(value1, value2, value3))
            {
                throw new ArgumentException("One or more of the arguments are not valid");
            }

            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
        }

        public T1 Value1 { get; }
        public T2 Value2 { get; }
        public T3 Value3 { get; }

        protected virtual bool Validate(T1 value1, T2 value2, T3 value3)
        {
            return true;
        }

        public virtual bool Equals(ValueObject<T1, T2, T3> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T1>.Default.Equals(Value1, other.Value1) && EqualityComparer<T2>.Default.Equals(Value2, other.Value2) && EqualityComparer<T3>.Default.Equals(Value3, other.Value3);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ValueObject<T1, T2, T3>)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = EqualityComparer<T1>.Default.GetHashCode(Value1);
                hashCode = (hashCode * 397) ^ EqualityComparer<T2>.Default.GetHashCode(Value2);
                hashCode = (hashCode * 397) ^ EqualityComparer<T3>.Default.GetHashCode(Value3);
                return hashCode;
            }
        }
    }

    [Serializable]
    public abstract class ValueObject<T1, T2, T3, T4> : ValueObject, IEquatable<ValueObject<T1, T2, T3, T4>>
    {
        protected ValueObject(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            if (!Validate(value1, value2, value3, value4))
            {
                throw new ArgumentException("One or more of the arguments are not valid");
            }

            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
            Value4 = value4;
        }

        public T1 Value1 { get; }
        public T2 Value2 { get; }
        public T3 Value3 { get; }
        public T4 Value4 { get; }

        protected virtual bool Validate(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            return true;
        }

        public virtual bool Equals(ValueObject<T1, T2, T3, T4> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T1>.Default.Equals(Value1, other.Value1) && EqualityComparer<T2>.Default.Equals(Value2, other.Value2) && EqualityComparer<T3>.Default.Equals(Value3, other.Value3) && EqualityComparer<T4>.Default.Equals(Value4, other.Value4);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ValueObject<T1, T2, T3, T4>)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = EqualityComparer<T1>.Default.GetHashCode(Value1);
                hashCode = (hashCode * 397) ^ EqualityComparer<T2>.Default.GetHashCode(Value2);
                hashCode = (hashCode * 397) ^ EqualityComparer<T3>.Default.GetHashCode(Value3);
                hashCode = (hashCode * 397) ^ EqualityComparer<T4>.Default.GetHashCode(Value4);
                return hashCode;
            }
        }
    }

    [Serializable]
    public abstract class ValueObject<T1, T2, T3, T4, T5> : ValueObject, IEquatable<ValueObject<T1, T2, T3, T4, T5>>
    {
        protected ValueObject(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            if (!Validate(value1, value2, value3, value4, value5))
            {
                throw new ArgumentException("One or more of the arguments are not valid");
            }

            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
            Value4 = value4;
            Value5 = value5;
        }

        public T1 Value1 { get; }
        public T2 Value2 { get; }
        public T3 Value3 { get; }
        public T4 Value4 { get; }
        public T5 Value5 { get; }

        protected virtual bool Validate(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            return true;
        }

        public virtual bool Equals(ValueObject<T1, T2, T3, T4, T5> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T1>.Default.Equals(Value1, other.Value1) && EqualityComparer<T2>.Default.Equals(Value2, other.Value2) && EqualityComparer<T3>.Default.Equals(Value3, other.Value3) && EqualityComparer<T4>.Default.Equals(Value4, other.Value4) && EqualityComparer<T5>.Default.Equals(Value5, other.Value5);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ValueObject<T1, T2, T3, T4, T5>)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = EqualityComparer<T1>.Default.GetHashCode(Value1);
                hashCode = (hashCode * 397) ^ EqualityComparer<T2>.Default.GetHashCode(Value2);
                hashCode = (hashCode * 397) ^ EqualityComparer<T3>.Default.GetHashCode(Value3);
                hashCode = (hashCode * 397) ^ EqualityComparer<T4>.Default.GetHashCode(Value4);
                hashCode = (hashCode * 397) ^ EqualityComparer<T5>.Default.GetHashCode(Value5);
                return hashCode;
            }
        }
    }

    [Serializable]
    public abstract class ValueObject<T1, T2, T3, T4, T5, T6> : ValueObject, IEquatable<ValueObject<T1, T2, T3, T4, T5, T6>>
    {
        protected ValueObject(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
        {
            if (!Validate(value1, value2, value3, value4, value5, value6))
            {
                throw new ArgumentException("One or more of the arguments are not valid");
            }

            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
            Value4 = value4;
            Value5 = value5;
            Value6 = value6;
        }

        public T1 Value1 { get; }
        public T2 Value2 { get; }
        public T3 Value3 { get; }
        public T4 Value4 { get; }
        public T5 Value5 { get; }
        public T6 Value6 { get; }

        protected virtual bool Validate(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
        {
            return true;
        }

        public virtual bool Equals(ValueObject<T1, T2, T3, T4, T5, T6> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T1>.Default.Equals(Value1, other.Value1) && EqualityComparer<T2>.Default.Equals(Value2, other.Value2) && EqualityComparer<T3>.Default.Equals(Value3, other.Value3) && EqualityComparer<T4>.Default.Equals(Value4, other.Value4) && EqualityComparer<T5>.Default.Equals(Value5, other.Value5) && EqualityComparer<T6>.Default.Equals(Value6, other.Value6);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ValueObject<T1, T2, T3, T4, T5, T6>)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = EqualityComparer<T1>.Default.GetHashCode(Value1);
                hashCode = (hashCode * 397) ^ EqualityComparer<T2>.Default.GetHashCode(Value2);
                hashCode = (hashCode * 397) ^ EqualityComparer<T3>.Default.GetHashCode(Value3);
                hashCode = (hashCode * 397) ^ EqualityComparer<T4>.Default.GetHashCode(Value4);
                hashCode = (hashCode * 397) ^ EqualityComparer<T5>.Default.GetHashCode(Value5);
                hashCode = (hashCode * 397) ^ EqualityComparer<T6>.Default.GetHashCode(Value6);
                return hashCode;
            }
        }
    }
}
