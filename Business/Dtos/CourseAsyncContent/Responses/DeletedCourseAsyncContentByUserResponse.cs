namespace Business.Dtos.CourseAsyncContent.Responses
{
    public class DeletedCourseAsyncContentByUserResponse
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid AsyncContentId { get; set; }
    }
}
