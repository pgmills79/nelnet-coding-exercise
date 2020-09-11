using NelnetProgrammingExercise.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

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

        public PersonModel() { }

        public PersonModel(PersonModel person) 
                    : this(person.Name, 
                    person.PreferredType, 
                    person.OpposedType = PetType.None, 
                    person.PreferredClassification, 
                    person.OpposedClassification = PetClassification.None, 
                    person.PreferredSize,
                    person.OpposedSize = PetSize.None) { }

        public PersonModel( string name, 
                            PetType preferredType = PetType.None, 
                            PetType opposedType = PetType.None, 
                            PetClassification preferredClassification = PetClassification.None,
                            PetClassification opposedClassification = PetClassification.None,
                            PetSize preferredSize = PetSize.None,
                            PetSize opposedSize = PetSize.None)
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

    public class DerivedPerson : PersonModel
    {
        public DerivedPerson(PersonModel person) : base(person) { }
    }
}
