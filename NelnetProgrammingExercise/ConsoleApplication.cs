using Microsoft.Extensions.Hosting;
using NelnetProgrammingExercise.Models;
using NelnetProgrammingExercise.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NelnetProgrammingExercise
{
    class ConsoleApplication : IHostedService, IDisposable
    {
        private readonly IPersonService _personService;
        private readonly IPetService _petService;
        private Timer _timer;        

        public ConsoleApplication(IPersonService persons, IPetService pets)
        {
            _personService = persons;
            _petService = pets;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(Run, null, TimeSpan.Zero,
                TimeSpan.FromDays(10)); //every 10 days

            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private void Run(object state)
        {

            List<PersonModel> persons = _personService.GetPersons();

            foreach (PersonModel person in persons)
            {
                Console.WriteLine(string.Format("Pets for {0}:", person.Name));

                List<PetModel> pets = _petService.GetPets();

                foreach (PetModel pet in pets)
                {
                    Console.WriteLine(string.Format("{0} would be a {1} pet. prefferred size is {2}", pet.Name, IsGood(person, pet), person.PreferredPetSize));
                }

                Console.WriteLine();
            }

            Console.ReadLine();         

        }


        private static string IsGood(PersonModel person, PetModel pet)
        {
            return person.PreferredClassification == pet.Classification || person.PreferredType == pet.Type
                ? "good"
                : "bad";
        }

    }
}
