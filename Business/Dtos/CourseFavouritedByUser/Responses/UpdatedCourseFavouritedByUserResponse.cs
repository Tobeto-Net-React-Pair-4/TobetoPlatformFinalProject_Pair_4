namespace Business.Dtos.CourseFavouritedByUser.Responses
{
    public class UpdatedCourseFavouritedByUserResponse
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }
    }
}
