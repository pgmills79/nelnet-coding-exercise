using System;
using System.Collections.Generic;
using System.Text;

namespace NelnetProgrammingExercise.Models
{
    public class PetModel 
    {
        public string Name { get; set; }
        public PetClassification Classification { get; set; }
        public PetType Type { get; set; }
        public PetSize Size { get; set; }
        public double Weight { get; set; }

        public PetModel() { }

        public PetModel(string name, PetClassification classification, PetType type, PetSize size, double weight)
        {
            Name = name;
            Classification = classification;
            Type = type;
            Size = size;
            Weight = weight;
        }
    }
}
