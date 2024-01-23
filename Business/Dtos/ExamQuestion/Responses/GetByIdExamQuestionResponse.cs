namespace Business.Dtos.ExamQuestion.Responses
{
    public class GetByIdExamQuestionResponse
    {
        public Guid Id { get; set; }
        public Guid ExamId { get; set; }
        public Guid TrueAnswerId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ExamTitle { get; set; }
    }
}
