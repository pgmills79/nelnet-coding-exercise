using NelnetProgrammingExercise.Helpers;
using NelnetProgrammingExercise.Models;
using NelnetProgrammingExercise.Services;
using System.Collections.Generic;

namespace NelnetProgrammingExercise.Repositories
{
    public class PersonRepository : IPersonService
    {
        private static List<Person> persons;      

        public List<Person> GetPersons()
        {

            persons = new List<Person>()
            {   
                new Person(name: "Dalinar", preferredType: PetType.Snake, preferredClassification:   PetClassification.Mammal, preferredSize: PetSize.Medium),
                new Person(name: "Kaladin", preferredType: PetType.Goldfish, preferredClassification:   PetClassification.Bird, preferredSize: PetSize.ExtraSmall),
                new Person(name: "Paul Don't Like dogs", preferredType: PetType.Goldfish,opposedType: PetType.Dog, preferredClassification:   PetClassification.Bird, preferredSize: PetSize.ExtraSmall),
                new Person(name: "Opposetd type negative everythiung", opposedType: PetType.Dog, preferredSize: PetSize.Medium, preferredType: PetType.Dog, preferredClassification: PetClassification.Mammal)
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
