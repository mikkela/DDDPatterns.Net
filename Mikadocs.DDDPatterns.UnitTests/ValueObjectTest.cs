using System;
using NUnit.Framework;

namespace Mikadocs.DDDPatterns.UnitTests
{
    class ValueObjectTest
    {
        #region Derived Value1 Object
        class SingleValuedValueObject : ValueObject<int>
        {
            public SingleValuedValueObject(int value1) : base(value1)
            {
            }
        }

        class DoubleValuedValueObject : ValueObject<int, bool>
        {
            public DoubleValuedValueObject(int value1, bool value2) : base(value1, value2)
            {
            }
        }

        class TripleValuedValueObject : ValueObject<int, int, int>
        {
            public TripleValuedValueObject(int value1, int value2, int value3) : base(value1, value2, value3)
            {
            }
        }

        class QuadrupleValuedValueObject : ValueObject<int, int, int, int>
        {
            public QuadrupleValuedValueObject(int value1, int value2, int value3, int value4) : base(value1, value2, value3, value4)
            {
            }
        }

        class QuintupleValuedValueObject : ValueObject<int, int, int, int, int>
        {
            public QuintupleValuedValueObject(int value1, int value2, int value3, int value4, int value5) : base(value1, value2, value3, value4, value5)
            {
            }
        }

        class SextupleValuedValueObject : ValueObject<int, int, int, int, int, int>
        {
            public SextupleValuedValueObject(int value1, int value2, int value3, int value4, int value5, int value6) : base(value1, value2, value3, value4, value5, value6)
            {
            }
        }

        class OtherSingleValuedValueObject : ValueObject<int>
        {
            public OtherSingleValuedValueObject(int value1) : base(value1)
            {
            }
        }

        class OtherDoubleValuedValueObject : ValueObject<int, bool>
        {
            public OtherDoubleValuedValueObject(int value1, bool value2) : base(value1, value2)
            {
            }
        }

        class OtherTripleValuedValueObject : ValueObject<int, int, int>
        {
            public OtherTripleValuedValueObject(int value1, int value2, int value3) : base(value1, value2, value3)
            {
            }
        }

        class OtherQuadrupleValuedValueObject : ValueObject<int, int, int, int>
        {
            public OtherQuadrupleValuedValueObject(int value1, int value2, int value3, int value4) : base(value1, value2, value3, value4)
            {
            }
        }

        class OtherQuintupleValuedValueObject : ValueObject<int, int, int, int, int>
        {
            public OtherQuintupleValuedValueObject(int value1, int value2, int value3, int value4, int value5) : base(value1, value2, value3, value4, value5)
            {
            }
        }

        class OtherSextupleValuedValueObject : ValueObject<int, int, int, int, int, int>
        {
            public OtherSextupleValuedValueObject(int value1, int value2, int value3, int value4, int value5, int value6) : base(value1, value2, value3, value4, value5, value6)
            {
            }
        }

        class FailingSingleValuedValueObject : SingleValuedValueObject
        {
            public FailingSingleValuedValueObject() : base(10)
            {
            }

            protected override bool Validate(int value)
            {
                return false;
            }
        }

        class FailingDoubleValuedValueObject : DoubleValuedValueObject
        {
            public FailingDoubleValuedValueObject() : base(11, false)
            {
            }

            protected override bool Validate(int value1, bool value2)
            {
                return false;
            }
        }

        class FailingTripleValuedValueObject : ValueObject<int, int, int>
        {
            public FailingTripleValuedValueObject() : base(1, 2, 3)
            {
            }

            protected override bool Validate(int value1, int value2, int value3)
            {
                return false;
            }
        }

        class FailingQuadrupleValuedValueObject : ValueObject<int, int, int, int>
        {
            public FailingQuadrupleValuedValueObject() : base(1, 2, 3, 4)
            {
            }

            protected override bool Validate(int value1, int value2, int value3, int value4)
            {
                return false;
            }
        }

        class FailingQuintupleValuedValueObject : ValueObject<int, int, int, int, int>
        {
            public FailingQuintupleValuedValueObject() : base(1, 2, 3, 4, 5)
            {
            }

            protected override bool Validate(int value1, int value2, int value3, int value4, int value5)
            {
                return false;
            }
        }

        class FailingSextupleValuedValueObject : ValueObject<int, int, int, int, int, int>
        {
            public FailingSextupleValuedValueObject() : base(1, 2, 3, 4, 5, 6)
            {
            }

            protected override bool Validate(int value1, int value2, int value3, int value4, int value5, int value6)
            {
                return false;
            }
        }
        #endregion

        [Test, TestCaseSource(nameof(ValueObjectsWithEqualProperties))]
        public void
            Given_two_Value_objects_with_equal_properties_When_they_are_compared_Then_they_are_considered_equal(ValueObject a, ValueObject b)
        {
            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(a));
            Assert.IsTrue(a.GetHashCode() == b.GetHashCode());
        }

        [Test, TestCaseSource(nameof(ValueObjectsWithDifferentProperties))]
        public void
            Given_two_Value_objects_with_different_properties_When_they_are_compared_Then_they_are_not_considered_equal(ValueObject a, ValueObject b)
        {
            Assert.IsFalse(a.Equals(b));
            Assert.IsFalse(b.Equals(a));
            Assert.IsFalse(a.GetHashCode() == b.GetHashCode());
        }

        [Test, TestCaseSource(nameof(ValueObjectsWithEqualPropertiesButDifferentSubtypes))]
        public void
            Given_two_Value_objects_with_same_properties_but_different_subtypes_When_they_are_compared_Then_they_are_not_considered_equal_but_same_hash_code(ValueObject a, ValueObject b)
        {
            Assert.IsFalse(a.Equals(b));
            Assert.IsFalse(b.Equals(a));
            Assert.IsTrue(a.GetHashCode() == b.GetHashCode());
        }

        [Test, TestCaseSource(nameof(ValueObjects))]
        public void
            Given_a_Value_object_When_it_is_compared_to_null_Then_they_are_not_considered_equal(ValueObject a)
        {
            Assert.IsFalse(a.Equals(null));
        }

        [Test, TestCaseSource(nameof(ValueObjects))]
        public void
            Given_a_Value_object_When_it_is_compared_to_itself_Then_they_are_considered_equal(ValueObject a)
        {
            Assert.IsTrue(a.Equals(a));
            Assert.IsTrue(a.GetHashCode() == a.GetHashCode());
        }

        [Test, TestCaseSource(nameof(InvalidValueObjectCreations))]
        public void
            Given_an_invalid_Value_Object_creation_When_it_is_created_Then_an_ArgumetException_is_thrown(Func<ValueObject> creator)
        {
            var exception = Assert.Throws<ArgumentException>(() => creator.Invoke());

            Assert.AreEqual("One or more of the arguments are not valid", exception.Message);
        }

        [Test]
        public void
            Given_a_typespecific_Value_object_When_it_is_compared_to_itself_Then_they_are_considered_equal()
        {
            ValueObject<int> a = new SingleValuedValueObject(1);
            Assert.IsTrue(a.Equals(a));
            Assert.IsTrue(a.GetHashCode() == a.GetHashCode());
        }

        [Test]
        public void
            Given_a_typespecific_Value_object_When_it_is_compared_to_null_Then_they_are_not_considered_equal()
        {
            ValueObject<int> a = new SingleValuedValueObject(1);
            Assert.IsFalse(a.Equals(null));
        }

        [Test]
        public void
            Given_a_typespecific_double_Value_object_When_it_is_compared_to_itself_Then_they_are_considered_equal()
        {
            ValueObject<int, bool> a = new DoubleValuedValueObject(1, false);
            Assert.IsTrue(a.Equals(a));
            Assert.IsTrue(a.GetHashCode() == a.GetHashCode());
        }

        [Test]
        public void
            Given_a_typespecific_double_Value_object_When_it_is_compared_to_null_Then_they_are_not_considered_equal()
        {
            ValueObject<int, bool> a = new DoubleValuedValueObject(1, false);
            Assert.IsFalse(a.Equals(null));
        }

        [Test]
        public void
            Given_a_typespecific_Triple_Value_object_When_it_is_compared_to_itself_Then_they_are_considered_equal()
        {
            ValueObject<int, int, int> a = new TripleValuedValueObject(1, 2, 3);
            Assert.IsTrue(a.Equals(a));
            Assert.IsTrue(a.GetHashCode() == a.GetHashCode());
        }

        [Test]
        public void
            Given_a_typespecific_Triple_Value_object_When_it_is_compared_to_null_Then_they_are_not_considered_equal()
        {
            ValueObject<int, int, int> a = new TripleValuedValueObject(1, 2, 3);
            Assert.IsFalse(a.Equals(null));
        }

        [Test]
        public void
            Given_a_typespecific_Quadruple_Value_object_When_it_is_compared_to_itself_Then_they_are_considered_equal()
        {
            ValueObject<int, int, int, int> a = new QuadrupleValuedValueObject(1, 2, 3, 4);
            Assert.IsTrue(a.Equals(a));
            Assert.IsTrue(a.GetHashCode() == a.GetHashCode());
        }

        [Test]
        public void
            Given_a_typespecific_Quadruple_Value_object_When_it_is_compared_to_null_Then_they_are_not_considered_equal()
        {
            ValueObject<int, int, int, int> a = new QuadrupleValuedValueObject(1, 2, 3, 4);
            Assert.IsFalse(a.Equals(null));
        }

        [Test]
        public void
            Given_a_typespecific_Quintuple_Value_object_When_it_is_compared_to_itself_Then_they_are_considered_equal()
        {
            ValueObject<int, int, int, int, int> a = new QuintupleValuedValueObject(1, 2, 3, 4, 5);
            Assert.IsTrue(a.Equals(a));
            Assert.IsTrue(a.GetHashCode() == a.GetHashCode());
        }

        [Test]
        public void
            Given_a_typespecific_Quintuple_Value_object_When_it_is_compared_to_null_Then_they_are_not_considered_equal()
        {
            ValueObject<int, int, int, int, int> a = new QuintupleValuedValueObject(1, 2, 3, 4, 5);
            Assert.IsFalse(a.Equals(null));
        }

        [Test]
        public void
            Given_a_typespecific_Sextuple_Value_object_When_it_is_compared_to_itself_Then_they_are_considered_equal()
        {
            ValueObject<int, int, int, int, int, int> a = new SextupleValuedValueObject(1, 2, 3, 4, 5, 6);
            Assert.IsTrue(a.Equals(a));
            Assert.IsTrue(a.GetHashCode() == a.GetHashCode());
        }

        [Test]
        public void
            Given_a_typespecific_Sextuple_Value_object_When_it_is_compared_to_null_Then_they_are_not_considered_equal()
        {
            ValueObject<int, int, int, int, int, int> a = new SextupleValuedValueObject(1, 2, 3, 4, 5, 6);
            Assert.IsFalse(a.Equals(null));
        }

        private static ValueObject[] ValueObjects =
        {
            new SingleValuedValueObject(10),
            new DoubleValuedValueObject(10, false),
            new TripleValuedValueObject(1, 2, 3),
            new QuadrupleValuedValueObject(1, 2, 3, 4),
            new QuintupleValuedValueObject(1, 2, 3, 4, 5),
            new SextupleValuedValueObject(1, 2, 3, 4, 5, 6),
        };

        static readonly object[] ValueObjectsWithEqualProperties =
        {
            new object[] {new SingleValuedValueObject(10), new SingleValuedValueObject(10),},
            new object[] {new DoubleValuedValueObject(11, true), new DoubleValuedValueObject(11, true), },
            new object[] {new TripleValuedValueObject(1, 2, 3), new TripleValuedValueObject(1, 2, 3), },
            new object[] {new QuadrupleValuedValueObject(1, 2, 3, 4), new QuadrupleValuedValueObject(1, 2, 3, 4), },
            new object[] {new QuintupleValuedValueObject(1, 2, 3, 4, 5), new QuintupleValuedValueObject(1, 2, 3, 4, 5), },
            new object[] {new SextupleValuedValueObject(1, 2, 3, 4, 5, 6), new SextupleValuedValueObject(1, 2, 3, 4, 5, 6), },
        };

        static readonly object[] ValueObjectsWithDifferentProperties =
        {
            new object[] {new SingleValuedValueObject(10), new SingleValuedValueObject(11),},
            new object[] {new DoubleValuedValueObject(11, true), new DoubleValuedValueObject(12, true), },
            new object[] {new DoubleValuedValueObject(11, true), new DoubleValuedValueObject(11, false), },
            new object[] {new TripleValuedValueObject(1, 2, 3), new TripleValuedValueObject(2, 2, 3), },
            new object[] {new TripleValuedValueObject(1, 2, 3), new TripleValuedValueObject(1, 3, 3), },
            new object[] {new TripleValuedValueObject(1, 2, 3), new TripleValuedValueObject(1, 2, 4), },
            new object[] {new QuadrupleValuedValueObject(1, 2, 3, 4), new QuadrupleValuedValueObject(2, 2, 3, 4), },
            new object[] {new QuadrupleValuedValueObject(1, 2, 3, 4), new QuadrupleValuedValueObject(1, 3, 3, 4), },
            new object[] {new QuadrupleValuedValueObject(1, 2, 3, 4), new QuadrupleValuedValueObject(1, 2, 4, 4), },
            new object[] {new QuadrupleValuedValueObject(1, 2, 3, 4), new QuadrupleValuedValueObject(1, 2, 3, 5), },
            new object[] {new QuintupleValuedValueObject(1, 2, 3, 4, 5), new QuintupleValuedValueObject(2, 2, 3, 4, 5), },
            new object[] {new QuintupleValuedValueObject(1, 2, 3, 4, 5), new QuintupleValuedValueObject(1, 3, 3, 4, 5), },
            new object[] {new QuintupleValuedValueObject(1, 2, 3, 4, 5), new QuintupleValuedValueObject(1, 2, 4, 4, 5), },
            new object[] {new QuintupleValuedValueObject(1, 2, 3, 4, 5), new QuintupleValuedValueObject(1, 2, 3, 5, 5), },
            new object[] {new QuintupleValuedValueObject(1, 2, 3, 4, 5), new QuintupleValuedValueObject(1, 2, 3, 4, 6), },
            new object[] {new SextupleValuedValueObject(1, 2, 3, 4, 5, 6), new SextupleValuedValueObject(2, 2, 3, 4, 5, 6), },
            new object[] {new SextupleValuedValueObject(1, 2, 3, 4, 5, 6), new SextupleValuedValueObject(1, 3, 3, 4, 5, 6), },
            new object[] {new SextupleValuedValueObject(1, 2, 3, 4, 5, 6), new SextupleValuedValueObject(1, 2, 4, 4, 5, 6), },
            new object[] {new SextupleValuedValueObject(1, 2, 3, 4, 5, 6), new SextupleValuedValueObject(1, 2, 3, 5, 5, 6), },
            new object[] {new SextupleValuedValueObject(1, 2, 3, 4, 5, 6), new SextupleValuedValueObject(1, 2, 3, 4, 6, 6), },
            new object[] {new SextupleValuedValueObject(1, 2, 3, 4, 5, 6), new SextupleValuedValueObject(1, 2, 3, 4, 5, 7), },
        };

        static readonly object[] ValueObjectsWithEqualPropertiesButDifferentSubtypes =
        {
            new object[] {new SingleValuedValueObject(10), new OtherSingleValuedValueObject(10),},
            new object[] {new DoubleValuedValueObject(11, true), new OtherDoubleValuedValueObject(11, true), },
            new object[] {new TripleValuedValueObject(1, 2, 3), new OtherTripleValuedValueObject(1, 2, 3), },
            new object[] {new QuadrupleValuedValueObject(1, 2, 3, 4), new OtherQuadrupleValuedValueObject(1, 2, 3, 4), },
            new object[] {new QuintupleValuedValueObject(1, 2, 3, 4, 5), new OtherQuintupleValuedValueObject(1, 2, 3, 4, 5), },
            new object[] {new SextupleValuedValueObject(1, 2, 3, 4, 5, 6), new OtherSextupleValuedValueObject(1, 2, 3, 4, 5, 6), },
        };

        static readonly Func<ValueObject>[] InvalidValueObjectCreations =
        {
            () => new FailingSingleValuedValueObject(),
            () => new FailingDoubleValuedValueObject(),
            () => new FailingTripleValuedValueObject(),
            () => new FailingQuadrupleValuedValueObject(),
            () => new FailingQuintupleValuedValueObject(),
            () => new FailingSextupleValuedValueObject(),
        };
    }
}
