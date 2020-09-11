using NelnetProgrammingExercise.Models;
using NelnetProgrammingExercise.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NelnetProgrammingExercise.Repositories
{
    public class PersonRepository : IPersonService
    {
        private static List<DerivedPerson> persons;      

        public List<DerivedPerson> GetPersons()
        {

            persons = new List<DerivedPerson>()
            {
                new DerivedPerson
                        (
                           new PersonModel()
                            {
                               Name = "Dalinar",
                               PreferredType = PetType.Snake,
                               PreferredClassification = PetClassification.Mammal,
                               PreferredSize = PetSize.Medium,
                           }                           
                    ),
                 new DerivedPerson
                        (
                           new PersonModel()
                            {
                               Name = "Kaladin",
                               PreferredType = PetType.Goldfish,
                               PreferredClassification = PetClassification.Bird,
                               PreferredSize = PetSize.ExtraSmall,
                           }
                    )
             };               

            return persons;
        }


    }
}
