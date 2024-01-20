namespace Business.Dtos.UserExam.Responses
{
    public class GetUserExamResponse
    {
        public Guid UserId { get; set; }
        public Guid ExamId { get; set; }
        public string UserEmail { get; set; }
        public string ExamTitle { get; set; }
    }
}
