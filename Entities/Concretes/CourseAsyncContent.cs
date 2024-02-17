using Core.Entities.Concrete;

namespace Entities.Concretes
{
    public class CourseAsyncContent : Entity<Guid>
    {
        public Guid CourseId { get; set; }
        public Guid AsyncContentId { get; set; }
        public Course Course { get; set; }
        public AsyncContent AsyncContent { get; set; }  
    }
}