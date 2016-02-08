using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mikadocs.DDDPatterns.UnitTests
{
    class EnumerableValueObjectTest
    {
        class ArrayValueObject : EnumerableValueObject<int>
        {
            public ArrayValueObject(int[] value1) : base(value1)
            {
            }
        }

        [Test]
        public void Given_two_sets_with_same_elements_When_they_are_compared_Then_they_are_considered_equal()
        {
            var sut1 = new ArrayValueObject(new[] {1, 2, 3});
            var sut2 = new ArrayValueObject(new[] { 1, 2, 3 });

            Assert.IsTrue(sut1.Equals(sut2));
            Assert.IsTrue(sut2.Equals(sut1));
            Assert.IsTrue(sut1.GetHashCode() == sut2.GetHashCode());
        }

        [Test]
        public void Given_two_sets_with_different_elements_When_they_are_compared_Then_they_are_not_considered_equal()
        {
            var sut1 = new ArrayValueObject(new[] { 1, 2, 3 });
            var sut2 = new ArrayValueObject(new[] { 1, 2, 4 });

            Assert.IsFalse(sut1.Equals(sut2));
            Assert.IsFalse(sut2.Equals(sut1));
            Assert.IsFalse(sut1.GetHashCode() == sut2.GetHashCode());
        }

        [Test]
        public void Given_a_set_When_an_EnumberableValueObject_is_created_from_the_set_Then_the_value_object_can_enumerate_the_set()
        {
            var set = new[] {1, 2, 3};

            var sut = new ArrayValueObject(set);

            CollectionAssert.AreEqual(set, sut);
        }
    }
}
