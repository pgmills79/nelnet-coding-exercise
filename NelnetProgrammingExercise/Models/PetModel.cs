
namespace NelnetProgrammingExercise.Models
{
    public class PetModel 
    {
        public string Name { get; set; }
        public PetClassification Classification { get; set; }
        public PetType Type { get; set; }       
        public double Weight { get; set; }

        public PetModel() { }

        public PetModel(string name, PetClassification classification, PetType type, double weight)
        {
            Name = name;
            Classification = classification;
            Type = type;
            Weight = weight;
        }
    }
}
