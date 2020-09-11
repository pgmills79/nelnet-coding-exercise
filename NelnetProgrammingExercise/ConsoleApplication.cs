using Microsoft.Extensions.Hosting;
using NelnetProgrammingExercise.Extensions;
using NelnetProgrammingExercise.Models;
using NelnetProgrammingExercise.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

            List<DerivedPerson> persons = _personService.GetPersons();
            List<PetModel> pets = _petService.GetPets();

            foreach (PersonModel person in persons)
            {
                Console.WriteLine("***************************************************************");
                Console.WriteLine(string.Format("Person: {0}", person.Name));
                Console.WriteLine();
                Console.WriteLine(string.Format("Preference Type: {0}", person.PreferredType));
                Console.WriteLine(string.Format("Preference Classification: {0}", person.PreferredClassification));
                Console.WriteLine(string.Format("Preference Size: {0}", person.PreferredSize));
                Console.WriteLine(string.Format("Opposed Type: {0}", person.OpposedType));
                Console.WriteLine(string.Format("Opposed Classification: {0}", person.OpposedClassification));
                Console.WriteLine(string.Format("Opposed Size: {0}", person.OpposedSize));

                //now is the animal a good fit
                Console.WriteLine(string.Format("Animals and are they a good fit for {0}?: ", person.Name));
                foreach (PetModel _pet in pets)
                {
                    Console.WriteLine(String.Format("Animal: {0} ", _pet.Name));
                    Console.WriteLine(String.Format("Fit?: {0} ", "This is a to do"));
                    Console.WriteLine();
                }

                Console.WriteLine("***************************************************************");

                

                //foreach (PetModel pet in pets)
                //{
                //    foreach(PetType t)
                //    Console.WriteLine(string.Format("Preff for {0}:", person.Name));
                //}

                Console.WriteLine();
            }

            Console.ReadLine();         

        }


        //private static string IsGood(PersonModel person, PetModel pet)
        //{
        //    return person.PreferredClassification == pet.Classification || person.PreferredType == pet.Type
        //        ? "good"
        //        : "bad";
        //}

    }
}
