namespace Business.Dtos.Course.Responses
{
    public class CreatedCourseResponse
    {
        public Guid Id { get; set; }
        public Guid InstructorId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}