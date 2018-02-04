using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.AutoNSubstitute;
using Moq;
using NSubstitute;
using NUnit.Framework;

namespace Autofixture.Tutorial.Tests
{
    public class IntegrationsWithMockingFrameworks
    {

        [Test]
        public void MockingWithMoq()
        {
            // Install with: 
            // Install-Package AutoFixture.AutoMoq
            // See http://blog.ploeh.dk/2010/08/19/AutoFixtureasanauto-mockingcontainer/

            // Arrange
            IFixture fixture = new Fixture()
                // Use the following method to enable tell AutoFixture to return mocked objects when asked to create abstract classes or interfaces.
                .Customize(new AutoMoqCustomization());
            // NOTE: You can also use AutoConfiguredMoqCustomization above. In this case AutoFixture will 
            // set properties on mocked objects and methods will return AutoFixture-generated values instead of default values.

            var searchTerm = fixture.Create<string>();

            // Freeze the mock for the repository
            var contactsRepoMock = fixture.Freeze<Mock<IContactsRepository>>();

            // Generate the system-under-test. The needed dependencies will be automatically injected into the constructor.
            var sut = fixture.Create<ContactsService>();

            // Act
            sut.SearchContacts(searchTerm);

            // Assert
            contactsRepoMock.Verify(r => r.ListContaining(searchTerm));
        }

        [Test]
        public void MockingWithNSubstitute()
        {
            // Install with:
            // Install-Package AutoFixture.AutoNSubstitute

            // See the example above for comments. The difference is only in the underlying mocking framework.

            // Arrange
            IFixture fixture = new Fixture()
                .Customize(new AutoNSubstituteCustomization());

            var searchTerm = fixture.Create<string>();
            var contactsRepoMock = fixture.Freeze<IContactsRepository>();

            var sut = fixture.Create<ContactsService>();

            // Act
            sut.SearchContacts(searchTerm);

            // Assert
            contactsRepoMock.Received().ListContaining(Arg.Is(searchTerm));
        }
    }
}
