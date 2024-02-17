namespace Business.Dtos.AsyncContent.Responses
{
    public class GetAsyncContentResponse
    {
        public Guid Id { get; set; }
        public string VideoUrl { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
    }


}
