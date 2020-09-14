using NelnetProgrammingExercise.Helpers;
using NelnetProgrammingExercise.Models;
using NelnetProgrammingExercise.Services;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;
using Dapper.Contrib.Extensions;

namespace NelnetProgrammingExercise.Repositories
{

    public class PersonRepository : IRepository<Person>
    {
        private static List<Person> persons;

        public void AddItems() {}

        public List<Person> GetItems()
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

        public void DeleteItems(List<Person> persons) 
        { 
           //dont do anything for demo purposes here
        }
    }



        #region "Dapper Option"
        public class PersonRepositorys : IRepository<Person>
    {
        private static List<Person> persons;

        public List<Person> GetItems()
        {
            using (var con = new MySqlConnection(Utils.GetHeWhoMustNotBeNamed()))
            {
                persons = con.Query<Person>("Select * from persons").ToList();
            }

            return persons;
        }

        public void AddItems()
        {
            persons = new List<Person>()
            {
                new Person(name: "Dalinar", preferredType: PetType.Snake, preferredClassification:   PetClassification.Mammal, preferredSize: PetSize.Medium),
                new Person(name: "Kaladin", preferredType: PetType.Goldfish, preferredClassification:   PetClassification.Bird, preferredSize: PetSize.ExtraSmall),
                new Person(name: "Paul Don't Like dogs", preferredType: PetType.Goldfish,opposedType: PetType.Dog, preferredClassification:   PetClassification.Bird, preferredSize: PetSize.ExtraSmall),
                new Person(name: "Opposetd type negative everythiung", opposedType: PetType.Dog, preferredSize: PetSize.Medium, preferredType: PetType.Dog, preferredClassification: PetClassification.Mammal)
            };

            using (var con = new MySqlConnection(Utils.GetHeWhoMustNotBeNamed()))
            {
                con.Insert(persons);
            }

        }

        public void DeleteItems(List<Person> persons)
        {
            using (var con = new MySqlConnection(Utils.GetHeWhoMustNotBeNamed()))
            {
                con.Delete(persons);
            }
        }

    }

    #endregion


}
