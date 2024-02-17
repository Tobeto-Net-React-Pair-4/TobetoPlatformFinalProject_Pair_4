using Core.Entities.Concrete;

namespace Entities.Concretes
{
    public class Calendar : Entity<Guid>
    {
        public Guid CourseId { get; set; }
        public Guid InstructorId { get; set; }
        public string InstructorName { get; set; }
        public DateTime EventDate { get; set; } 
        public string EventDetails { get; set; } 
        public string StatusOfCompleted { get; set; }

        public Course Course { get; set; }
        public Instructor Instructor{ get; set; }

        public ICollection<UserCalendar> UserCalendars { get; set; }
    }
}
