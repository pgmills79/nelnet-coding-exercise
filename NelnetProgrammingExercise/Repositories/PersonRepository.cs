using NelnetProgrammingExercise.Models;
using NelnetProgrammingExercise.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NelnetProgrammingExercise.Repositories
{
    public class PersonRepository : IPersonService
    {
        private static List<PersonModel> persons;      

        public List<PersonModel> GetPersons()
        {
            persons = new List<PersonModel>
            {
                new PersonModel()
                {
                    Name = "Dalinar",
                    PreferredClassification = PetClassification.Mammal,
                    PreferredType = PetType.Snake,
                    PreferredPetSize = PetSize.Medium
                },
                new PersonModel()
                {
                    Name = "Kaladin",
                    PreferredClassification = PetClassification.Bird,
                    PreferredType = PetType.Goldfish,
                    PreferredPetSize = PetSize.ExtraSmall
                }
            };

            return persons;
        }


    }
}
