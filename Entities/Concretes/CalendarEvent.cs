using Core.Entities.Concrete;

namespace Entities.Concretes
{
    public class CalendarEvent : Entity<Guid>
    {
        public Guid CourseId { get; set; }
        public string InstructorName { get; set; }
        public DateTime EventDate { get; set; } // Etkinlik tarihi
        public string EventDetails { get; set; } // Etkinlik detayları
        public Course Course { get; set; }
    }
}
