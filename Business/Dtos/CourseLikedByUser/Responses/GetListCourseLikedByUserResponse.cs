namespace Business.Dtos.CourseLikedByUser.Responses
{
    public class GetListCourseLikedByUserResponse
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }
    }
}
