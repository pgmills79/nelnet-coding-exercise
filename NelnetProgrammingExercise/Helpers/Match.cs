using NelnetProgrammingExercise.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NelnetProgrammingExercise.Helpers
{
    public static class Match
    {

        public static MatchStatus IsGoodMatch(PersonModel person, PetModel pet) 
        {
            //1.Type
            //2.Classification
            //3.Weight
            //4.Default Type / Classification / Weight on person object
           
            
            //Good is the highest order so return 
            

            if (person.PreferredType.Equals(pet.Type)) return MatchStatus.Good;

            //we would return 
            if (person.PreferredClassification.Equals(pet.Classification) ) return MatchStatus.Bad;

            return MatchStatus.Bad;
        }
    }
}
