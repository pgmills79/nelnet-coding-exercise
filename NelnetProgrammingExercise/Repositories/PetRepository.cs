using Dapper;
using MySql.Data.MySqlClient;
using NelnetProgrammingExercise.Models;
using NelnetProgrammingExercise.Services;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace NelnetProgrammingExercise.Repositories
{
    public class PetRepository : IPetService
    {
        private static List<Pet> pets;

        public List<Pet> GetPets()
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
    }

    #region "Extra Credit Dapper"

    public class PetRepositorys : IPetService
    {
        private static List<Pet> pets;

        public List<Pet> GetPets()
        {
            using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["LocalServer"].ToString()))
            {
                pets = con.Query<Pet>("SELECT * FROM pet").ToList();
            }

            return pets;
        }
    }

    #endregion




}
