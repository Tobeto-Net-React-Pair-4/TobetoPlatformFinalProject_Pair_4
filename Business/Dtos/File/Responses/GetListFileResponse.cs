namespace Business.Dtos.File.Responses
{
    public class GetListFileResponse
    {
        public Guid Id { get; set; }
        public Guid AssignmentId { get; set; }
        public Guid UserId { get; set; }
        public string FilePath { get; set; }
    }
}
