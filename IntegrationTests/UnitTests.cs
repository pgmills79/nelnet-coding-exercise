using Microsoft.Extensions.DependencyInjection;
using NelnetProgrammingExercise.Models;
using NelnetProgrammingExercise.Repositories;
using NelnetProgrammingExercise.Services;
using System;
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

        public async Task DisposeAsync()
        {
            await _serviceProvide.DisposeAsync();
        }

        [Fact]
        public async Task Match_Should_Return_Bad()
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
        public async Task Match_Should_Return_Good()
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


    }
}
