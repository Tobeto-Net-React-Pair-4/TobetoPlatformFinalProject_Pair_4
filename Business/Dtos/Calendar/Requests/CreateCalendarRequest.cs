namespace Business.Dtos.Course.Requests
{
    public class CreateCalendarRequest
    {
        public Guid CourseId { get; set; }
        public Guid InstructorId { get; set; }
        public string InstructorName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventDetails { get; set; }
        public string StatusOfCompleted { get; set; }
    }
}