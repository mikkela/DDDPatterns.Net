using NUnit.Framework;

namespace Mikadocs.DDDPatterns.UnitTests
{
    class NumberBasedEntityIdentityFactoryTest
    {
        public class MyNumberBasedEntityIdentity : NumberBasedEntityIdentity
        {
            internal MyNumberBasedEntityIdentity(long value) : base(value)
            {
            }
        }

        [Test]
        public void
            Given_a_NumberBasedEntityIdentityFactory_When_CreateEntityIdentity_is_called_with_a_value_Then_a_NumberBasedEntityIdentity_identified_by_the_value_is_returned
            ()
        {
            const long val = 35353;
            var sut = NumberBasedEntityIdentityFactory.CreateEntityIdentity<MyNumberBasedEntityIdentity>(val);

            Assert.AreEqual(val, sut.Value1);
            Assert.AreEqual(new MyNumberBasedEntityIdentity(val), sut);
        }
    }
}