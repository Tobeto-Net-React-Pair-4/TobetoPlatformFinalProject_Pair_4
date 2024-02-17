namespace Business.Dtos.CourseAsyncContent.Requests
{
    public class CreateCourseAsyncContentRequest
    {
        public Guid CourseId { get; set; }
        public Guid AsyncContentId { get; set; }
    }
}
