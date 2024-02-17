namespace Business.Dtos.CourseFavouritedByUser.Requests
{
    public class CreateCourseFavouritedByRequest
    {
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }
    }
}
