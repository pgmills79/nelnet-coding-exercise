using NelnetProgrammingExercise.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NelnetProgrammingExercise.Models
{
    public class PersonModel
    {
        public string Name { get; set; }

        public List<PetType> PreferredTypes { get; set; }
        public List<PetType> OpposedTypes { get; set; }

        public List<PetClassification> PreferredClassifications { get; set; }
        public List<PetClassification> OpposedClassifications { get; set; }

        public List<PetSize> PreferredSizes { get; set; }
        public List<PetSize> OpposedSizes { get; set; }

        public PersonModel() { }

        public PersonModel( string name, 
                            List<PetType> preferredTypes = null, 
                            List<PetType> opposedTypes = null, 
                            List<PetClassification> preferredClassifications = null,
                            List<PetClassification> opposedClassifications = null,
                            List<PetSize> preferredSizes = null,
                            List<PetSize> opposedSizes = null)
        {
            PreferredTypes = preferredTypes;
            OpposedTypes = opposedTypes.RemovePreferredTypeFromOpposed(PreferredTypes);

            PreferredClassifications = preferredClassifications;
            opposedClassifications = opposedClassifications.RemovePreferredClassifictionsFromOpposed(PreferredClassifications);

            PreferredSizes = preferredSizes;
            OpposedSizes = opposedSizes.RemovePreferredSizesFromOpposed(PreferredSizes);

        }
    }
}
