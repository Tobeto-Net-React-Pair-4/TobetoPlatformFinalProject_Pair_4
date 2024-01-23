using Business.Dtos.User.Responses;

namespace Business.Dtos.Course.Requests
{
    public class CreateCourseRequest
    {
        public Guid InstructorId { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public bool Status { get; set; } = false;


    }
}