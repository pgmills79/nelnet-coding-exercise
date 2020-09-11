using NelnetProgrammingExercise.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NelnetProgrammingExercise.Services
{
    public interface IPersonService
    {
        List<DerivedPerson> GetPersons();
    }
}
