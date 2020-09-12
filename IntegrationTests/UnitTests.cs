using Microsoft.Extensions.DependencyInjection;
using NelnetProgrammingExercise.Extensions;
using NelnetProgrammingExercise.Helpers;
using NelnetProgrammingExercise.Models;
using NelnetProgrammingExercise.Repositories;
using NelnetProgrammingExercise.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class ServiceFixture
    {
        public ServiceFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IPersonService, PersonRepository>();
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }

    [Collection("ProjectCollection")]
    public class UnitTests : IClassFixture<ServiceFixture>
    {

        private ServiceProvider _serviceProvide;
        private IPersonService _personService;

        public UnitTests(ServiceFixture fixture)
        {
            _serviceProvide = fixture.ServiceProvider;
            _personService = _serviceProvide.GetService<IPersonService>();
        }

        [Fact]
        public void Match_Should_Return_Bad()
        {
            //arrange
            Person person = new Person("No Dogs", opposedType: PetType.Dog);
            Pet pet = new Pet("Fido", classification: PetClassification.Mammal, type: PetType.Dog, weight: 20.0);            

            //Act
            MatchStatus statusResult = _personService.GetMatchStatus(person, pet);

            //Assert
            MatchStatus expectedResult = MatchStatus.Bad;
            Assert.Equal(expectedResult.ToString(), statusResult.ToString());

            //dispose of service
           
        }

        [Fact]
        public void Match_Should_Return_Good()
        {
            //arrange
            Person person = new Person("Dogs", preferredType: PetType.Dog, opposedClassification: PetClassification.Mammal, opposedSize: PetSize.ExtraSmall);
            Pet pet = new Pet("Fido", classification: PetClassification.Mammal, type: PetType.Dog, weight: .01);

            //Act
            MatchStatus statusResult = _personService.GetMatchStatus(person, pet);

            //Assert
            MatchStatus expectedResult = MatchStatus.Good;
            Assert.Equal(expectedResult.ToString(), statusResult.ToString());

        }

        [Fact]
        public void Preffered_Size_Opposed_Classification_Should_Return_Bad()
        {
            //arrange
            Person person = new Person("Dogs", preferredSize: PetSize.ExtraLarge, opposedClassification: PetClassification.Mammal);
            Pet pet = new Pet("Fido", classification: PetClassification.Mammal, type: PetType.Dog, weight: 100);

            //Act
            MatchStatus statusResult = _personService.GetMatchStatus(person, pet);

            //Assert
            MatchStatus expectedResult = MatchStatus.Bad;
            Assert.Equal(expectedResult.ToString(), statusResult.ToString());

        }

        [Fact]
        public void Preffered_Classification_Opposed_Type_Should_Return_Bad()
        {
            //arrange
            Person person = new Person("Dogs", preferredClassification: PetClassification.Mammal, opposedType: PetType.Dog);
            Pet pet = new Pet("Fido", classification: PetClassification.Mammal, type: PetType.Dog, weight: 100);

            //Act
            MatchStatus statusResult = _personService.GetMatchStatus(person, pet);

            //Assert
            MatchStatus expectedResult = MatchStatus.Bad;
            Assert.Equal(expectedResult.ToString(), statusResult.ToString());

        }

        [Fact]
        public void Same_Preffered_Type_Opposed_Should_Set_Opposed_To_None()
        {
            //arrange
            List<Person> persons = new List<Person>() { new Person("Dogs", preferredType: PetType.Dog, opposedType: PetType.Dog) };            
            Methods.SetSameOppossedToNone(persons);

            //Act
            PetType statusResult = persons[0].OpposedType;

            //Assert
            PetType expectedResult = PetType.None;
            Assert.Equal(expectedResult.ToString(), statusResult.ToString());

        }

        [Fact]
        public void Same_Preffered_Classification_Opposed_Should_Set_Opposed_To_None()
        {
            //arrange
            List<Person> persons = new List<Person>() { new Person("Dogs", preferredClassification: PetClassification.Bird, opposedClassification: PetClassification.Bird) };
            Methods.SetSameOppossedToNone(persons);

            //Act
            PetClassification statusResult = persons[0].OpposedClassification;

            //Assert
            PetClassification expectedResult = PetClassification.None;
            Assert.Equal(expectedResult.ToString(), statusResult.ToString());

        }

        [Fact]
        public void Same_Preffered_Size_Opposed_Should_Set_Opposed_To_None()
        {
            //arrange
            List<Person> persons = new List<Person>() { new Person("Dogs", preferredSize: PetSize.Small, opposedSize: PetSize.Small) };
            Methods.SetSameOppossedToNone(persons);

            //Act
            PetSize statusResult = persons[0].OpposedSize;

            //Assert
            PetSize expectedResult = PetSize.None;
            Assert.Equal(expectedResult.ToString(), statusResult.ToString());

        }

        [Fact]
        public void Opposed_Type_Should_Return_Same_Opposed_Type()
        {
            //arrange
            PetType expectedResult = PetType.Dog;

            List<Person> persons = new List<Person>() { new Person("Dogs", opposedType: expectedResult) };
            Methods.SetSameOppossedToNone(persons);

            //Act
            PetType statusResult = persons[0].OpposedType;

            //Assert
            Assert.Equal(expectedResult.ToString(), statusResult.ToString());

        }

        [Fact]
        public void Opposed_Size_Should_Return_Same_Opposed_Size()
        {
            //arrange
            PetSize expectedResult = PetSize.Small;

            List<Person> persons = new List<Person>() { new Person("Dogs", opposedSize: expectedResult) };
            Methods.SetSameOppossedToNone(persons);

            //Act
            PetSize statusResult = persons[0].OpposedSize;

            //Assert
            Assert.Equal(expectedResult.ToString(), statusResult.ToString());

        }

        [Fact]
        public void Opposed_Classification_Should_Return_Same_Opposed_Classification()
        {
            //arrange
            PetClassification expectedResult = PetClassification.Arachnid;

            List<Person> persons = new List<Person>() { new Person("Dogs", opposedClassification: expectedResult) };
            Methods.SetSameOppossedToNone(persons);

            //Act
            PetClassification statusResult = persons[0].OpposedClassification;

            //Assert
            Assert.Equal(expectedResult.ToString(), statusResult.ToString());

        }

        [Fact]
        public void PetWeight_Should_Return_ExtraLarge_Size()
        {
            //arrange          
            Pet pet = new Pet("Test", weight: 50, classification: PetClassification.Bird, type: PetType.Canary);

            //Act
            PetSize statusResult = pet.Size();

            //Assert
            PetSize expectedResult = PetSize.ExtraLarge;
            Assert.Equal(expectedResult.ToString(), statusResult.ToString());

        }

        [Fact]
        public void PetWeight_Should_Return_Medium_Size()
        {
            //arrange          
            Pet pet = new Pet("Test", weight: 10, classification: PetClassification.Bird, type: PetType.Canary);

            //Act
            PetSize statusResult = pet.Size();

            //Assert
            PetSize expectedResult = PetSize.Medium;
            Assert.Equal(expectedResult.ToString(), statusResult.ToString());

        }

        [Fact]
        public void Negative_PetWeight_Should_Return_ExtraSmall_Size()
        {
            //arrange          
            Pet pet = new Pet("Test", weight: -10, classification: PetClassification.Bird, type: PetType.Canary);

            //Act
            PetSize statusResult = pet.Size();

            //Assert
            PetSize expectedResult = PetSize.ExtraSmall;
            Assert.Equal(expectedResult.ToString(), statusResult.ToString());
        }

        [Fact]
        public void Person_With_AnyOpposed_Should_Return_True()
        {
            //arrange          
            Person person = new Person("Dogs", opposedClassification: PetClassification.Mammal);

            //Act
            bool statusResult = person.AnyOpposed();

            //Assert
            bool expectedResult = true;
            Assert.Equal(expectedResult.ToString(), statusResult.ToString());
        }

        [Fact]
        public void Person_With_NoOpposed_Should_Return_False()
        {
            //arrange          
            Person person = new Person("Dogs", preferredType: PetType.Dog);

            //Act
            bool statusResult = person.AnyOpposed();

            //Assert
            bool expectedResult = false;
            Assert.Equal(expectedResult.ToString(), statusResult.ToString());
        }


    }
}