namespace Business.Dtos.CourseFavouritedByUser.Requests
{
    public class UpdateCourseFavouritedByRequest
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }
    }
}
