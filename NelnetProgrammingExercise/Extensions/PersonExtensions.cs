using NelnetProgrammingExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NelnetProgrammingExercise.Extensions
{
    public static class PersonExtensions
    {

        //public static List<PetType> RemovePreferredTypeFromOpposed(this PetType opposedTypes, List<PetType> preferredTypes)  
        //{
        //    //if nothing in the lists just return the original opposed tye
        //    if (!opposedTypes.Any() || !preferredTypes.Any())
        //        return opposedTypes;         

        //    List<PetType> originalOpposed = opposedTypes;
        //    List<PetType> updatedOpposed = originalOpposed.Except(preferredTypes).ToList();

        //    return updatedOpposed;
        //}

        //public static List<PetClassification> RemovePreferredClassifictionsFromOpposed(this List<PetClassification> opposedClassifications, 
        //    List<PetClassification> preferredClassifications)
        //{
        //    //if nothing in the lists just return the original opposed tye
        //    if (!opposedClassifications.Any() || !preferredClassifications.Any())
        //        return opposedClassifications;

        //    List<PetClassification> originalOpposed = opposedClassifications;
        //    List<PetClassification> updatedOpposed = originalOpposed.Except(preferredClassifications).ToList();

        //    return updatedOpposed;
        //}

        //public static List<PetSize> RemovePreferredSizesFromOpposed(this List<PetSize> opposedSizes,
        //   List<PetSize> preferredSizes)
        //{
        //    //if nothing in the lists just return the original opposed tye
        //    if (!opposedSizes.Any() || !preferredSizes.Any())
        //        return opposedSizes;

        //    List<PetSize> originalOpposed = opposedSizes;
        //    List<PetSize> updatedOpposed = originalOpposed.Except(preferredSizes).ToList();

        //    return updatedOpposed;
        //}

        //public static List<T> RemovePreferredFromOpposed<T, P>(this List<T> opposed,
        //   List<P> preferred)
        //{
        //    //if nothing in the lists just return the original opposed tye
        //    if (!opposed.Any() || !preferred.Any())
        //        return opposed;

        //    List<T> originalOpposed = opposed;
        //    List<T> updatedOpposed = originalOpposed.Except(preferred).ToList();

        //    return updatedOpposed;
        //}

        public static List<T> OrEmptyIfNull<T>(this List<T> source)
        {
            return source ?? new List<T>();
        }
    }
}
