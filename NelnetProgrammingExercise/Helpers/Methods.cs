using NelnetProgrammingExercise.Models;
using System.Collections.Generic;
using System.Linq;

namespace NelnetProgrammingExercise.Helpers
{
    public static class Methods
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
    }
}
