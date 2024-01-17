using Core.Entities;

namespace Entities.Concretes
{
    public class Instructor : Entity<Guid>
    {
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<CalendarEvent> CalendarEvents { get; set; }
        
    }
}
