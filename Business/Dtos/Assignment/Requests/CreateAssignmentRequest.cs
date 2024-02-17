namespace Business.Dtos.Assignment.Requests
{
    public class CreateAssignmentRequest
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public string AssignmentType { get; set; }
        public string VideoUrl { get; set; }
    }

}
