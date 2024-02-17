using Core.Entities.Concrete;

namespace Entities.Concretes
{
    public class CourseFavouritedByUser : Entity<Guid>
    {
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }
        public Course Course { get; set; }
        public User User { get; set; }
    }
}