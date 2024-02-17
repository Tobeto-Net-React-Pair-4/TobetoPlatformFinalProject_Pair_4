namespace Business.Dtos.AsyncContent.Requests
{
    public class UpdateAsyncContentRequest
    {
        public string VideoUrl { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }

    }
}
