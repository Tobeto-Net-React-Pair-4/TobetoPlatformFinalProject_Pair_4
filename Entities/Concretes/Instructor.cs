using Core.Entities.Concrete;

namespace Entities.Concretes
{
    public class Instructor : Entity<Guid>
    {
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Calendar> Calendars { get; set; }
        public ICollection<InstructorSession> InstructorSessions { get; set; }


    }
}
