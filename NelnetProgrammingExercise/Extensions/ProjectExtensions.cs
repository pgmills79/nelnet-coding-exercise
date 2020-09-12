using NelnetProgrammingExercise.Models;

namespace NelnetProgrammingExercise.Extensions
{
    public static class ProjectExtensions
    {
        public static PetSize Size(this Pet pet)
        {
            if ((pet.Weight > 0 && pet.Weight <= 1.0) || pet.Weight < 0) return PetSize.ExtraSmall;
            if (pet.Weight > 1.0 && pet.Weight <= 5.0) return PetSize.Small;
            if (pet.Weight > 5.0 && pet.Weight <= 15.0) return PetSize.Medium;
            if (pet.Weight > 15.0 && pet.Weight <= 30.0) return PetSize.Large;            
            
            return PetSize.ExtraLarge;
        }

        public static bool AnyOpposed(this Person person)
        {
            return (
                        person.OpposedType != PetType.None
                        ||
                        person.OpposedClassification != PetClassification.None
                        ||
                        person.OpposedSize != PetSize.None
                     );
        }
    }
}
