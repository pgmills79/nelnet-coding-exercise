
namespace NelnetProgrammingExercise.Models
{
    public class PersonModel
    {
        public virtual string Name { get; set; }

        public virtual PetType PreferredType { get; set; }
        public virtual PetType OpposedType { get; set; }

        public virtual PetClassification PreferredClassification { get; set; }
        public virtual PetClassification OpposedClassification { get; set; }

        public virtual PetSize PreferredSize { get; set; }
        public virtual PetSize OpposedSize { get; set; }

        public virtual MatchStatus Match { get; set; }

        public PersonModel() { }


    }
   

    public class Person : PersonModel
    {

        public override PetType PreferredType { get; set; }

        public override PetClassification PreferredClassification { get; set; }

        public override PetSize PreferredSize { get; set; }

        public override MatchStatus Match { get ; set; }

        public Person() { }       

        public Person(      
                            string name,
                            PetType preferredType = PetType.None,
                            PetType opposedType = PetType.None,
                            PetClassification preferredClassification = PetClassification.None,
                            PetClassification opposedClassification = PetClassification.None,
                            PetSize preferredSize = PetSize.None,
                            PetSize opposedSize = PetSize.None,
                            MatchStatus match = MatchStatus.Good
                       ) 
        {
            Name = name;
            PreferredType = preferredType;
            OpposedType = opposedType;
            PreferredClassification = preferredClassification;
            OpposedClassification = opposedClassification;
            PreferredSize = preferredSize;
            OpposedSize = opposedSize;
            Match = match;
        }
    }
}
