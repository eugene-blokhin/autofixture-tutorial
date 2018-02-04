using AutoFixture;
using NUnit.Framework;

namespace Autofixture.Tutorial.Tests
{
    public class CustomizingSingleInstanceCreation
    {
        [Test]
        public void CustomizeSingleObjectCreation()
        {
            IFixture fixture = new Fixture();

            // You can configure a single creation using method IFixture.Build<T>()
            // followed by a chain of customizing calls and finishing up by calling method IFixture.Create()
            var contact = fixture.Build<Contact>()
                .With(c => c.FirstName, "Eugene")
                .With(c => c.LastName, "Blokhin")
                .Without(c => c.Email)
                .Create();

            Assert.That(contact.FirstName, Is.EqualTo("Eugene"));
            Assert.That(contact.LastName, Is.EqualTo("Blokhin"));
            Assert.That(contact.Address, Is.Not.Null);
            Assert.That(contact.Email, Is.Null);
        }
    }
}
