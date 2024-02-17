namespace Business.Dtos.CourseAsyncContent.Requests
{
    public class CreateCourseAsyncContentByUserRequest
    {
        public Guid CourseId { get; set; }
        public Guid AsyncContentId { get; set; }
    }
}
