using NelnetProgrammingExercise.Models;
using System.Collections.Generic;

namespace NelnetProgrammingExercise.Services
{
    public interface IPersonService
    {
        List<Person> GetPersons();

        MatchStatus GetMatchStatus(PersonModel person, PetModel pet);
    }
}
