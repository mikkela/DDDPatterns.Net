using System;
using NUnit.Framework;

namespace Mikadocs.DDDPatterns.UnitTests
{
    class GloballyUniqueEntityIdentityFactoryTest
    {
        public class MyGloballyUniqueEntityIdentity : GloballyUniqueEntityIdentity
        {
            internal MyGloballyUniqueEntityIdentity(Guid value) : base(value)
            {
            }
        }

        [Test]
        public void
            Given_a_GloballyUniqueEntityIdentityFactory_When_CreateNewEntityIdentity_is_called_Then_a_new_unique_GloballyUniqueEntityIdentity_is_returned
            ()
        {
            var sut1 = GloballyUniqueEntityIdentityFactory.CreateNewEntityIdentity<MyGloballyUniqueEntityIdentity>();
            var sut2 = GloballyUniqueEntityIdentityFactory.CreateNewEntityIdentity<MyGloballyUniqueEntityIdentity>();

            Assert.AreEqual(sut1, sut2);
        }

        [Test]
        public void
            Given_a_GloballyUniqueEntityIdentityFactory_When_CreateEntityIdentity_is_called_with_a_value_Then_a_GloballyUniqueEntityIdentity_identified_by_the_value_is_returned
            ()
        {
            Guid guid = Guid.NewGuid();
            var sut = GloballyUniqueEntityIdentityFactory.CreateEntityIdentity<MyGloballyUniqueEntityIdentity>(guid);

            Assert.AreEqual(guid, sut.Value1);
            Assert.AreEqual(new MyGloballyUniqueEntityIdentity(guid), sut);
        }
    }
}