using System;
using System.Reflection;
using System.Text.RegularExpressions;
using AutoFixture;
using AutoFixture.Kernel;
using NUnit.Framework;

namespace Autofixture.Tutorial.Tests
{
    public class ImplementingCustomization
    {
        [Test]
        public void UsingCustomSpecimenBuilder()
        {
            IFixture fixture = new Fixture();

            // You can also customize object creation with you own implementation of ISpecimenBuilder.
            // In this example we create a class ZipCodeFormatCustomization which implements
            // generation of a postcode according to the Dutch format: "{4 digits} {2 letters}".
            //
            // See the ZipCodeFormatCustomization below.
            fixture.Customizations.Add(new ZipCodeFormatCustomization());

            var address = fixture.Create<Address>();
            Assert.True(Regex.IsMatch(address.ZipCode, @"^\d{4} [A-Z]{2}$"));
        }

        public class ZipCodeFormatCustomization : ISpecimenBuilder
        {
            public object Create(object request, ISpecimenContext context)
            {
                var isZipCodeProperty =
                    request is PropertyInfo propertyInfo
                    && propertyInfo.DeclaringType == typeof(Address)
                    && propertyInfo.Name == nameof(Address.ZipCode);

                if (!isZipCodeProperty)
                    return new NoSpecimen();

                var rnd = new Random();
                var number = rnd.Next(1000, 9999);
                var letter1 = (char)rnd.Next('A', 'Z');
                var letter2 = (char)rnd.Next('A', 'Z');

                return $"{number} {letter1}{letter2}";
            }
        }
    }
}
