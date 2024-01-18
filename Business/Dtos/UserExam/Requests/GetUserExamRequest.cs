namespace Business.Dtos.UserExam.Requests
{
    public class GetUserExamRequest
    {
        public Guid UserId { get; set; }
        public Guid ExamId { get; set; }
    }
}
