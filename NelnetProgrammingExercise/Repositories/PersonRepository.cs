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
                    PreferredTypes = new List<PetType>{ PetType.Snake },
                    PreferredClassifications = new List<PetClassification>{ PetClassification.Mammal },                    
                    PreferredSizes = new List<PetSize>{ PetSize.Medium }
                },
                new PersonModel()
                {
                    Name = "Kaladin",
                    PreferredTypes = new List<PetType>{ PetType.Goldfish },
                    PreferredClassifications = new List<PetClassification>{ PetClassification.Bird },
                    PreferredSizes = new List<PetSize>{ PetSize.ExtraSmall }
                }
            };

            return persons;
        }


    }
}
