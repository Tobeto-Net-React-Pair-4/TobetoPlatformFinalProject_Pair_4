using System.Text.Json.Serialization;
using Core.Entities.Concrete;

namespace Entities.Concretes
{
    public class Category : Entity<Guid>
    {
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }

    }

}
