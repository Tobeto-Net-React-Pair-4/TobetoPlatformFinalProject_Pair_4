using Core.Entities;

namespace Entities.Concretes
{
    public class Instructor : Entity<Guid>
    {
        public string Name { get; set; }
    }
}
