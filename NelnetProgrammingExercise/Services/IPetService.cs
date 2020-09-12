using NelnetProgrammingExercise.Models;
using System.Collections.Generic;

namespace NelnetProgrammingExercise.Services
{
    public interface IPetService
    {
        List<Pet> GetPets();
    }
}
