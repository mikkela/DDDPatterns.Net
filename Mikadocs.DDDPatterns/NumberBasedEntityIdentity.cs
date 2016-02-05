using System;
using System.Reflection;

namespace Mikadocs.DDDPatterns
{
    [Serializable]
    public abstract class NumberBasedEntityIdentity : ValueObject<long>
    {
        protected NumberBasedEntityIdentity(long value) : base(value)
        {
        }
    }

    public static class NumberBasedEntityIdentityFactory
    {
        public static T CreateEntityIdentity<T>(long value) where T : NumberBasedEntityIdentity
        {
            return (T)
                typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null,
                    new[] { typeof(long) }, null).Invoke(new object[] { value });
        }
    }
}
