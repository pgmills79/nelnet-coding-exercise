using NelnetProgrammingExercise.Models;

namespace NelnetProgrammingExercise.Extensions
{
    public static class PetExtensions
    {
        public static PetSize Size(this PetModel pet)
        {
            if ((pet.Weight > 0 && pet.Weight <= 1.0) || pet.Weight < 0) return PetSize.ExtraSmall;
            if (pet.Weight > 1.0 && pet.Weight <= 5.0) return PetSize.Small;
            if (pet.Weight > 5.0 && pet.Weight <= 15.0) return PetSize.Medium;
            if (pet.Weight > 15.0 && pet.Weight <= 30.0) return PetSize.Large;            
            
            return PetSize.ExtraLarge;
        }
    }
}
