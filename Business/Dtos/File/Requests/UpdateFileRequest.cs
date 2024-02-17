namespace Business.Dtos.File.Requests
{
    public class UpdateFileRequest
    {
        public Guid Id { get; set; }
        public Guid AssignmentId { get; set; }
        public Guid UserId { get; set; }
        public string FilePath { get; set; }

    }
}
