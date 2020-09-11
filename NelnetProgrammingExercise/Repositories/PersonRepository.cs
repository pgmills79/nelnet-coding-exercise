using NelnetProgrammingExercise.Helpers;
using NelnetProgrammingExercise.Models;
using NelnetProgrammingExercise.Services;
using System.Collections.Generic;

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

        public MatchStatus GetMatchStatus(PersonModel person, PetModel pet) 
        {
            //if there are ANY opposed values we call the derived class
            if (
                person.OpposedType != PetType.None
                ||
                person.OpposedClassification != PetClassification.None
                ||
                person.OpposedSize != PetSize.None
                )
            {
                //then we implement the opposed derived class
                DerivedMatch derivedClass = new DerivedMatch();
                return derivedClass.GetStatus(person, pet);
            }
            else
                //there were no oppositions so default check
                return new Match().GetStatus(person, pet);
        
        }

    }
}
