
using Dapper.Contrib.Extensions;

namespace NelnetProgrammingExercise.Models
{
    [Table("person")]
    public class PersonModel
    {
        public virtual string Name { get; set; }

        public virtual PetType PreferredType { get; set; }
        public virtual PetType OpposedType { get; set; }

        public virtual PetClassification PreferredClassification { get; set; }
        public virtual PetClassification OpposedClassification { get; set; }

        public virtual PetSize PreferredSize { get; set; }
        public virtual PetSize OpposedSize { get; set; }

        public PersonModel() { }


    }
   

    public class Person : PersonModel
    {


        public Person() { }       

        public Person(      
                            string name,
                            PetType preferredType = PetType.None,
                            PetType opposedType = PetType.None,
                            PetClassification preferredClassification = PetClassification.None,
                            PetClassification opposedClassification = PetClassification.None,
                            PetSize preferredSize = PetSize.None,
                            PetSize opposedSize = PetSize.None
                       ) 
        {
            Name = name;
            PreferredType = preferredType;
            OpposedType = opposedType;
            PreferredClassification = preferredClassification;
            OpposedClassification = opposedClassification;
            PreferredSize = preferredSize;
            OpposedSize = opposedSize;
        }
    }
}
