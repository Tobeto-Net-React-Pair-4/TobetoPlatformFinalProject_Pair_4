using System.Text.Json.Serialization;
using Core.Entities;

namespace Entities.Concretes
{
    public class Course : Entity<Guid>
    {
        
        public Guid CategoryId { get; set; }
        public Guid InstructorId { get; set; }
        public List<CalendarEvent> CalendarEvents { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? StartOfDate { get; set; }
        public DateTime? EndOfDate { get; set; }
        public DateTime? TimeOfSpent { get; set; }
        public DateTime? EstimatedTime { get; set; }
        public string Producer { get; set; }
        public int? ContentCount { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } // Eğitim durumu (bitmiş, devam eden, satın alınmış, başlamamış)

        public Category Category { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; }

        //content kısmı????!!!!???
    }
}
