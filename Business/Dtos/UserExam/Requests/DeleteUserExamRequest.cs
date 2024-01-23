namespace Business.Dtos.UserExam.Requests
{
    public class DeleteUserExamRequest
    {
        public Guid UserId { get; set; }
        public Guid ExamId { get; set; }
    }
}
