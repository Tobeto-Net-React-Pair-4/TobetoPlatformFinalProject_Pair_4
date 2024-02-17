namespace Business.Dtos.CourseFavouritedByUser.Requests
{
    public class CreateCourseFavouritedByUserRequest
    {
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }
    }
}
