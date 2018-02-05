# AutoFixture tutorial
This repository contains a set of examples demonstrating how to use AutoFixture to generate test data for unit tests.

You can find more about autofixture by this links:
* [NuGet package](https://www.nuget.org/packages/AutoFixture)
* [AutoFixture GitHub repo](https://github.com/AutoFixture/AutoFixture)

Install with: `Install-Package AutoFixture`

# Examples files
* [01-ValueTypesGeneration.cs](https://github.com/eugene-blokhin/autofixture-tutorial/blob/master/Autofixture.Tutorial.Tests/01-ValueTypesGeneration.cs) - generation of values of primitive and non-primitive value types
* [02-ComplexObjectsGeneration.cs](https://github.com/eugene-blokhin/autofixture-tutorial/blob/master/Autofixture.Tutorial.Tests/02-ComplexObjectsGeneration.cs) - generation of instances of reference types
* [03-CustomizingFixtureObject.cs](https://github.com/eugene-blokhin/autofixture-tutorial/blob/master/Autofixture.Tutorial.Tests/03-CustomizingFixtureObject.cs) - customizing of a fixture object
* [04-CustomizingSingleInstanceCreation.cs](https://github.com/eugene-blokhin/autofixture-tutorial/blob/master/Autofixture.Tutorial.Tests/04-CustomizingSingleInstanceCreation.cs) - customizing single object creation
* [05-ImplementingCustomization.cs](https://github.com/eugene-blokhin/autofixture-tutorial/blob/master/Autofixture.Tutorial.Tests/05-ImplementingCustomization.cs) - demonstrates how to implement ISpecimenBuilder for more complex custimizations
* [06-IntegrationsWithMockingFrameworks.cs](https://github.com/eugene-blokhin/autofixture-tutorial/blob/master/Autofixture.Tutorial.Tests/06-IntegrationsWithMockingFrameworks.cs) - demonstartes integration with Moq and NSubstitute libraries
