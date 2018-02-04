using System.Linq;
using AutoFixture;
using NUnit.Framework;

namespace Autofixture.Tutorial.Tests
{
    public class ComplexObjectsGeneration
    {
        [Test]
        public void CreateComplexTypes()
        {
            IFixture fixture = new Fixture();

            // AutoFixture can also create instances of reference types.
            // Unlike with value types, there is no restriction on mutability of the type
            Address address = fixture.Create<Address>();

            Assert.That(address.AddressLine1, Is.Not.Null);
            Assert.That(address.AddressLine2, Is.Not.Null);
            Assert.That(address.City, Is.Not.Null);
            Assert.That(address.ZipCode, Is.Not.Null);
            Assert.That(address.Country, Is.Not.Null);
        }

        [Test]
        public void CreateGraphsOfComplexTypes()
        {
            IFixture fixture = new Fixture();

            // You can also create construct graph of nested complex objects.
            // In the example below a contact has an address.
            // Both types are custom reference types.

            Contact contact = fixture.Create<Contact>();

            Assert.That(contact.FirstName, Is.Not.Null);
            Assert.That(contact.LastName, Is.Not.Null);
            Assert.That(contact.Phone, Is.Not.Null);
            Assert.That(contact.Email, Is.Not.Null);
            Assert.That(contact.Address, Is.Not.Null);

            Address address = contact.Address;

            Assert.That(address.AddressLine1, Is.Not.Null);
            Assert.That(address.AddressLine2, Is.Not.Null);
            Assert.That(address.City, Is.Not.Null);
            Assert.That(address.ZipCode, Is.Not.Null);
            Assert.That(address.Country, Is.Not.Null);
        }

        [Test]
        public void CreateSequencesOfComplexTypes()
        {
            IFixture fixture = new Fixture();

            // Just like with value types, you can also generate sequences of complex objects
            var contact = fixture.CreateMany<Contact>(10);
            Assert.That(contact.Count(), Is.EqualTo(10));
        }
    }
}