using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using NelnetProgrammingExercise.Helpers;
using NelnetProgrammingExercise.Models;
using NelnetProgrammingExercise.Services;
using System.Collections.Generic;
using System.Linq;

namespace NelnetProgrammingExercise.Repositories
{
    public class PetRepository : IRepository<Pet> 
    {
        private static List<Pet> pets;

        public void AddItems() { }

        public List<Pet> GetItems()
        {

            pets = new List<Pet>
             {
                new Pet(name: "Garfield", classification:  PetClassification.Mammal,type: PetType.Cat, weight: 20.0),
                new Pet(name: "Odie", classification:  PetClassification.Mammal,type: PetType.Dog, weight: 15.0),
                new Pet(name: "Peter Parker", classification:  PetClassification.Arachnid,type: PetType.Spider, weight: 0.5),
                new Pet(name: "Kaa", classification:  PetClassification.Reptile,type: PetType.Snake, weight: 25.0),
                new Pet(name: "Nemo", classification:  PetClassification.Fish,type: PetType.Goldfish, weight: 0.5),
                new Pet(name: "Alpha", classification:  PetClassification.Fish,type: PetType.Betta, weight: 0.1),
                new Pet(name: "Splinter", classification:  PetClassification.Mammal,type: PetType.Rat, weight: 0.5),
                new Pet(name: "Coco", classification:  PetClassification.Bird,type: PetType.Parrot, weight: 6.0),
                new Pet(name: "Tweety", classification:  PetClassification.Bird,type: PetType.Canary, weight: 0.5)
             };

            return pets;
        }

        public void DeleteItems(List<Pet> pets){}

    }


    #region "Dapper Option"
    public class PetRepositorys : IRepository<Pet>
    {
        private static List<Pet> pets;

        public List<Pet> GetItems()
        {
            using (var con = new MySqlConnection(Methods.GetHeWhoMustNotBeNamed()))
            {
                pets = con.Query<Pet>("SELECT * FROM pets").ToList();
            }

            return pets;
        }

        public void AddItems()
        {
            pets = new List<Pet>
             {
                new Pet(name: "Garfield", classification:  PetClassification.Mammal,type: PetType.Cat, weight: 20.0),
                new Pet(name: "Odie", classification:  PetClassification.Mammal,type: PetType.Dog, weight: 15.0),
                new Pet(name: "Peter Parker", classification:  PetClassification.Arachnid,type: PetType.Spider, weight: 0.5),
                new Pet(name: "Kaa", classification:  PetClassification.Reptile,type: PetType.Snake, weight: 25.0),
                new Pet(name: "Nemo", classification:  PetClassification.Fish,type: PetType.Goldfish, weight: 0.5),
                new Pet(name: "Alpha", classification:  PetClassification.Fish,type: PetType.Betta, weight: 0.1),
                new Pet(name: "Splinter", classification:  PetClassification.Mammal,type: PetType.Rat, weight: 0.5),
                new Pet(name: "Coco", classification:  PetClassification.Bird,type: PetType.Parrot, weight: 6.0),
                new Pet(name: "Tweety", classification:  PetClassification.Bird,type: PetType.Canary, weight: 0.5)
             };

            using (var con = new MySqlConnection(Methods.GetHeWhoMustNotBeNamed()))
            {
                con.Insert(pets);
            }
        }

        public void DeleteItems(List<Pet> pets)
        {
            using (var con = new MySqlConnection(Methods.GetHeWhoMustNotBeNamed()))
            {
                con.Delete(pets);
            }
        }

    }

    #endregion
}






