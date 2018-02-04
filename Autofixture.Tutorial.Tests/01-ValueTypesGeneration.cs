using System;
using System.Linq;
using AutoFixture;
using NUnit.Framework;
using System.Collections.Generic;

namespace Autofixture.Tutorial.Tests
{
    public class ValueTypesGeneration
    {
        [Test]
        public void CreatePrimitiveTypes()
        {
            // This is a main type in Autofixture. Generation on any test data starts from it.
            IFixture fixture = new Fixture();

            // The easiest way to generate a value is to use the IFixture.Create<T>() method.
            int intVal = fixture.Create<int>();
            string stringVal = fixture.Create<string>();
            double doubleVal = fixture.Create<double>();

            // By default Autofixture always return different random values
            var anotherIntVal = fixture.Create<int>();
            Assert.That(anotherIntVal, Is.Not.EqualTo(intVal));
        }

        [Test]
        public void CreateImmutableValueTypes()
        {
            IFixture fixture = new Fixture();

            // Autofixture can also create values of non-primitive value types.
            ImmutablePoint immutablePoint = fixture.Create<ImmutablePoint>();
            DateTime time1 = fixture.Create<DateTime>();
            DateTimeOffset time2 = fixture.Create<DateTimeOffset>();

            // By default it can only handle value types that have a defined constructor with parameters.
            Assert.Throws(
                Is.InstanceOf<ObjectCreationException>(),
                () => fixture.Create<MutablePoint>()
            );

            // If you need to create a value of a mutable value type 
            // and set the properties afterwards, you can instruct AutoFixture to do so
            // by using a Customization. Customizations will be covered in-depth in another tutorial file.
            fixture.Customize(new SupportMutableValueTypesCustomization());
            MutablePoint mutablePoint = fixture.Create<MutablePoint>();
        }

        [Test]
        public void CreateSequenceOfValues()
        {
            IFixture fixture = new Fixture();

            // You can also generate arrays of values like shown below

            // By default Autofixture creates collections of 3 elements
            var stringsArray = fixture.CreateMany<string>();
            Assert.That(stringsArray.Count(), Is.EqualTo(3));

            // But you can override the number of elements by supplying a parameter
            var stringsArray10 = fixture.CreateMany<string>(10);
            Assert.That(stringsArray10.Count(), Is.EqualTo(10));

            // Again, you can generate not-primitive types as well
            var dateTimeArray20 = fixture.CreateMany<DateTime>(20);
            Assert.That(dateTimeArray20.Count(), Is.EqualTo(20));
            
            // Another option is to use method IFixture.AddManyTo(collection, count).
            // It will add *count* items into the *collection*
            var listOfInts = new List<int>();
            fixture.AddManyTo(listOfInts, 30);
            Assert.That(listOfInts.Count, Is.EqualTo(30));
        }
    }
}
