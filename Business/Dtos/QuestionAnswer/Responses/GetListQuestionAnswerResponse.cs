namespace Business.Dtos.QuestionAnswer.Responses
{
    public class GetListQuestionAnswerResponse
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
