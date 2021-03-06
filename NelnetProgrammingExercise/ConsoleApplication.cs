﻿using NelnetProgrammingExercise.Extensions;
using NelnetProgrammingExercise.Helpers;
using NelnetProgrammingExercise.Models;
using NelnetProgrammingExercise.Services;
using System;
using System.Collections.Generic;

namespace NelnetProgrammingExercise
{
    class ConsoleApplication
    {
        private readonly IRepository<Person> _personService;
        private readonly IRepository<Pet> _petService;

        public ConsoleApplication(IRepository<Person> persons, IRepository<Pet> pets)
        {
            _personService = persons;
            _petService = pets;
        }

        public void Run()
        {
            //add items
            _personService.AddItems();
            _petService.AddItems();

            //get items
            List<Person> persons = _personService.GetItems();
            List<Pet> pets = _petService.GetItems();

            
            foreach (Person person in persons)
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
                foreach (Pet pet in pets)
                {
                    Console.WriteLine(String.Format("Animal: {0} ", pet.Name));

                    Console.WriteLine(
                        String.Format("Type: {0}, Classification: {1}, Size: {2} ",
                        pet.Type,
                        pet.Classification,
                        pet.Size()));

                    Console.WriteLine(String.Format("Fit (Good/Bad): {0} ", Utils.GetMatchStatus(person, pet)));
                    Console.WriteLine();
                }

                Console.WriteLine("***************************************************************");
            }

            //clear the data out
            _personService.DeleteItems(persons);
            _petService.DeleteItems(pets);

            Console.ReadLine();

           

        }

    }
}
