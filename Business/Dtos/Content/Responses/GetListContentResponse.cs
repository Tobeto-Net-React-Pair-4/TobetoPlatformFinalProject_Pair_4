namespace Business.Dtos.Content.Responses
{
    public class GetListContentResponse
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string Type { get; set; }
        public string VideoUrl { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public string Language { get; set; }
        public string Detail { get; set; }
    }
}