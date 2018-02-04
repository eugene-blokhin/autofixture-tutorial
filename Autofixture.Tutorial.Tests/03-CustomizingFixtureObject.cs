﻿using System;
using System.Xml.Linq;
using AutoFixture;
using NUnit.Framework;

namespace Autofixture.Tutorial.Tests
{
    public class CustomizingFixtureObject
    {
        [Test]
        public void RegisterFactoryFunction()
        {
            IFixture fixture = new Fixture();
            
            // Using the IFixture.Register<T>(Func<...,T>) method you can specify a factory method that
            // will be used to build an instance if type T.
            var count = 0;
            fixture.Register<int>(() => count++);

            var int0 = fixture.Create<int>();
            var int1 = fixture.Create<int>();
            Assert.That(int0, Is.EqualTo(0));
            Assert.That(int1, Is.EqualTo(1));

            var intArray = fixture.CreateMany<int>(3);
            Assert.That(intArray, Is.EquivalentTo(new [] {2, 3, 4}));
            
            // You can also register a factory function that depends on one or more input parameters.
            // These input parameters also get generated by Autofixture
            fixture.Register((Address a) =>
            {
                return new XDocument(
                    new XElement(nameof(Address),
                        new XElement(nameof(a.AddressLine1), a.AddressLine1),
                        new XElement(nameof(a.AddressLine2), a.AddressLine2),
                        new XElement(nameof(a.Country), a.Country),
                        new XElement(nameof(a.City), a.City),
                        new XElement(nameof(a.ZipCode), a.ZipCode)
                    )
                );
            });

            var xmlDocument = fixture.Create<XDocument>();
            Console.WriteLine(xmlDocument);

            /*
            Will output something like:

            <Address>
              <AddressLine1>AddressLine12725e7f4-e5b9-4044-a0cc-8af2f3c1a1b7</AddressLine1>
              <AddressLine2>AddressLine2f3ba6254-d902-409d-baed-15de2a997741</AddressLine2>
              <Country>Country0e9e0eb8-9f27-4194-bfe4-ddc5e111094e</Country>
              <City>Citye42ce649-7aa1-4a73-a389-cf281876fdc0</City>
              <ZipCode>ZipCodeb2e7b62d-f050-4474-b838-6a45785bcd14</ZipCode>
            </Address>
            */
        }

        [Test]
        public void InjectInstanceOfType()
        {
            IFixture fixture = new Fixture();

            var contact = new Contact
            {
                FirstName = "Eugene",
                LastName = "Blokhin"
            };

            // You can inject a concrete instance of a type into the fixture.
            // It tells Autofixture to return your instance every time when an instance
            // of the given type is requested.
            fixture.Inject(contact);

            var createdContact = fixture.Create<Contact>();
            Assert.That(createdContact, Is.EqualTo(contact));
        }

        [Test]
        public void FreezeInstanceOfType()
        {
            IFixture fixture = new Fixture();
            
            // In the previous example is shown how to inject your own instance of a type into the fixture.
            // There are test scenarios when you might like to create an instance with Autofixture and then inject it.
            // You could do that with invocations of methods IFixture.Create<T>(...) and IFixture.Inject(...).
            // For your convenience Autofixture provides a method called Freeze<T>() that combines those two calls:
            // it creates an instance, injects, and returns it.

            var contact = fixture.Freeze<Contact>();

            contact.FirstName = "Eugene";
            contact.LastName = "Blokhin";

            var createdContact = fixture.Create<Contact>();
            Assert.That(createdContact, Is.EqualTo(contact));
        }
    }
}
