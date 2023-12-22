using Business.Dtos.User.Responses;

namespace Business.Dtos.Course.Responses
{
    public class GetListCourseResponse
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid InstructorId { get; set; }
        public Guid UserId { get; set; }
        public string CategoryName { get; set; }
        public string InstructorName { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public List<string> Users { get; set; }
    }
}