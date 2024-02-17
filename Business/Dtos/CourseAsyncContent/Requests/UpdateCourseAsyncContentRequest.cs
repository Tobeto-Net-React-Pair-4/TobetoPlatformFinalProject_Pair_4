namespace Business.Dtos.CourseAsyncContent.Requests
{
    public class UpdateCourseAsyncContentRequest
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid AsyncContentId { get; set; }
    }
}
