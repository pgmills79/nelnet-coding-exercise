using NelnetProgrammingExercise.Models;
using System.Collections.Generic;

namespace NelnetProgrammingExercise.Services
{
    public interface IRepository<T> where T : IEntity
    {
        void AddItems();
        List<T> GetItems();
        void DeleteItems(List<T> entity);
      
    }
}
