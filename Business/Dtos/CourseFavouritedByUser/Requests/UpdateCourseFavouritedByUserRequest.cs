namespace Business.Dtos.CourseFavouritedByUser.Requests
{
    public class UpdateCourseFavouritedByUserRequest
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }
    }
}
