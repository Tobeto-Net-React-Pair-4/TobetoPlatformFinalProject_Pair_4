namespace Business.Dtos.ExamQuestion.Requests
{
    public class UpdateExamQuestionRequest
    {
        public Guid Id { get; set; }
        public Guid ExamId { get; set; }
        public Guid TrueAnswerId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
