namespace Business.Dtos.QuestionAnswer.Requests
{
    public class UpdateQuestionAnswerRequest
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
