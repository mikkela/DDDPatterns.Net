using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mikadocs.DDDPatterns.UnitTests
{
    class ArrayValueObjectTest
    {
        [Test]
        public void
            Given_null_When_an_ArrayValueObject_is_created_from_the_array_Then_an_ArgumentException_is_thrown
            ()
        {

            Assert.Throws<ArgumentException>(() => new ArrayValueObject<int>(null));            
        }

        [Test]
        public void
            Given_an_array_When_an_ArrayValueObject_is_created_from_the_array_Then_the_value_object_can_enumerate_the_array
            ()
        {
            var a = new[] { 1, 2, 3 };

            var sut = new ArrayValueObject<int>(a);

            CollectionAssert.AreEqual(a, sut);
        }

        [Test]
        public void
            Given_an_array_When_an_ArrayValueObject_is_created_from_the_array_Then_the_array_can_be_changed_without_changing_the_value_object
            ()
        {
            var a = new[] {1, 2, 3};

            var sut = new ArrayValueObject<int>(a);

            a[0] = 34;

            CollectionAssert.AreNotEqual(a, sut);
        }

        [Test]
        public void Given_two_value_objects_with_arrays_with_different_length_When_they_are_compared_Then_they_are_not_considered_equal()
        {
            var a1 = new[] { 1, 2, 3, };
            var a2 = new[] { 1, 2 };

            Assert.IsFalse(new ArrayValueObject<int>(a1).Equals(new ArrayValueObject<int>(a2)));
            Assert.IsFalse(new ArrayValueObject<int>(a2).Equals(new ArrayValueObject<int>(a1)));
            Assert.IsFalse(new ArrayValueObject<int>(a1).GetHashCode() == new ArrayValueObject<int>(a2).GetHashCode());
        }

        [Test]
        public void Given_two_value_objects_with_arrays_with_same_length_and_different_elements_When_they_are_compared_Then_they_are_not_considered_equal()
        {
            var a1 = new[] { 1, 2, 3, };
            var a2 = new[] { 1, 2, 4 };

            Assert.IsFalse(new ArrayValueObject<int>(a1).Equals(new ArrayValueObject<int>(a2)));
            Assert.IsFalse(new ArrayValueObject<int>(a2).Equals(new ArrayValueObject<int>(a1)));
            Assert.IsFalse(new ArrayValueObject<int>(a1).GetHashCode() == new ArrayValueObject<int>(a2).GetHashCode());
        }

        [Test]
        public void
            Given_two_value_objects_with_arrays_with_same_length_and_same_elements_When_they_are_compared_Then_they_are_considered_equal
            ()
        {
            var a1 = new[] {1, 2, 3,};
            var a2 = new[] { 1, 2, 3, };

            Assert.IsTrue(new ArrayValueObject<int>(a1).Equals(new ArrayValueObject<int>(a2)));
            Assert.IsTrue(new ArrayValueObject<int>(a2).Equals(new ArrayValueObject<int>(a1)));
            Assert.IsTrue(new ArrayValueObject<int>(a1).GetHashCode() == new ArrayValueObject<int>(a2).GetHashCode());
        }
            
            
    }
}
