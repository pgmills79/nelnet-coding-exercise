using NelnetProgrammingExercise.Extensions;
using NelnetProgrammingExercise.Models;

namespace NelnetProgrammingExercise.Helpers
{
    public class Match    {

        public virtual MatchStatus Status { get; set; }

        public Match() { }

        //method that we will derive from (base classed is called if NO opposed attributes)
        public virtual MatchStatus GetStatus(Person person, Pet pet) 
        {
                  
                return
                    (person.PreferredType == pet.Type
                    || person.PreferredClassification == pet.Classification
                    || person.PreferredSize == pet.Size()
                    ) ? MatchStatus.Good : MatchStatus.Bad;
        }   


    }

    public class DerivedMatch : Match
    {
        //There are opposed attributes so we inherite and oveeride the defaul method from base class
        public override MatchStatus GetStatus(Person person, Pet pet)
        {            

            //Type is priorityy #1 (hierarchy) and is opposed we want to return bad match
            if (person.OpposedType == pet.Type)
                return MatchStatus.Bad;

            //Type is priority #1 (hierarchy)  so return good if preferred is same
            if (person.PreferredType == pet.Type)
                return MatchStatus.Good;

            //Type classification is  priority #2 (hierarchy) so return good 
            //if preferred is same (we already accounted for Type above)
            if (person.PreferredClassification == pet.Classification)
                return MatchStatus.Good;

            //Size is  priority #3 (hierarchy) so return good 
            //if preferred is same and opposed Classification is not opposed
            if (person.PreferredSize == pet.Size() && person.OpposedClassification != pet.Classification)
                return MatchStatus.Good;
            if (person.PreferredSize == pet.Size() && person.OpposedClassification == pet.Classification)
                return MatchStatus.Bad;

            //If the classification is opposed at this point then the match is bad
            if (person.OpposedSize == pet.Size())
                return MatchStatus.Bad;


            //default to good match
            return MatchStatus.Good;
        }

        





    }

   
}
