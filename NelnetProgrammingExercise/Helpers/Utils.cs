using NelnetProgrammingExercise.Extensions;
using NelnetProgrammingExercise.Models;
using System.Collections.Generic;
using System.Linq;

namespace NelnetProgrammingExercise.Helpers
{
    public static class Utils
    {
        public static List<Person> SetSameOppossedToNone(List<Person> persons)
        {
            List<Person> updatedPersons = persons.Select(c => 
                                                        { 
                                                            c.OpposedType = c.OpposedType == c.PreferredType ? PetType.None : c.OpposedType;
                                                            c.OpposedClassification = c.OpposedClassification == c.PreferredClassification ? PetClassification.None : c.OpposedClassification;
                                                            c.OpposedSize = c.OpposedSize == c.PreferredSize ? PetSize.None : c.OpposedSize;
                                                            return c; 
                                                        }
                                                        ).ToList();

            return updatedPersons;       
        }

        public static MatchStatus GetMatchStatus(Person person, Pet pet)
        {
            //if there are ANY opposed values we call the derived class
            if (person.AnyOpposed())
            {
                //then we implement the opposed derived class
                DerivedMatch derivedClass = new DerivedMatch();
                return derivedClass.GetStatus(person, pet);
            }
            else
                //there were no oppositions so default check
                return new Match().GetStatus(person, pet);

        }

        public static string GetHeWhoMustNotBeNamed()
        {
            //I would usually NEVER have this string here
            return "server=localhost;uid=pmills;port=3306;pwd=^X2e34cZM0GI;database=practice";
        }
    }
}
