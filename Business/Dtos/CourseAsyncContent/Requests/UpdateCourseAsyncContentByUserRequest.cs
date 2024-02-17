namespace Business.Dtos.CourseAsyncContent.Requests
{
    public class UpdateCourseAsyncContentByUserRequest
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid AsyncContentId { get; set; }
    }
}
