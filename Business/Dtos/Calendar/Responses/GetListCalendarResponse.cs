namespace Business.Dtos.Course.Responses
{
    public class GetListCalendarResponse
    {
        public Guid Id { get; set; }
        public string InstructorName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventDetails { get; set; }

    }
}