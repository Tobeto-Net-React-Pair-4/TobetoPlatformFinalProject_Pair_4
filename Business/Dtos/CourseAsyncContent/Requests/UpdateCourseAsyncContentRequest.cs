namespace Business.Dtos.CourseAsyncContent.Requests
{
    public class UpdateCourseAsyncContentRequest
    {
        public Guid CourseId { get; set; }
        public Guid AsyncContentId { get; set; }
    }
}
