namespace Business.Dtos.Course.Responses
{
    public class UpdatedCalendarResponse
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string InstructorName { get; set; }
        public DateTime EventDate { get; set; } 
        public string EventDetails { get; set; } 
    }
}