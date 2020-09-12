
namespace NelnetProgrammingExercise.Models
{
    public class PetModel 
    {
        public string Name { get; set; }
        public PetClassification Classification { get; set; }
        public PetType Type { get; set; }       
        public double Weight { get; set; }

        public PetModel() { }


    }

    public class Pet : PetModel
    {
        public Pet() { }

        public Pet(string name, PetClassification classification, PetType type, double weight)
        {
            Name = name;
            Classification = classification;
            Type = type;
            Weight = weight;
        }
    }
}
