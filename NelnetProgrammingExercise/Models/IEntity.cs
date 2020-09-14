using Dapper.Contrib.Extensions;

namespace NelnetProgrammingExercise.Models
{
    public class IEntity
    {
        [Key]
        public long Id { get; set; }

        public virtual string Name { get; set; }
    }
}
