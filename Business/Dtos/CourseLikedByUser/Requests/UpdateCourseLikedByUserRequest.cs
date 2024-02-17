namespace Business.Dtos.CourseLikedByUser.Requests
{
    public class UpdateCourseLikedByUserRequest
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }

    }
}
