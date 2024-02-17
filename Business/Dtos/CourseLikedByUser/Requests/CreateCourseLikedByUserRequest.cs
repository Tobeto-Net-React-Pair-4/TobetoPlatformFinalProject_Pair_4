namespace Business.Dtos.CourseLikedByUser.Requests
{
    public class CreateCourseLikedByUserRequest
    {
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }

    }
}
