namespace Business.Dtos.Appeal.Responses
{
    public class CreatedAppealResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Form { get; set; }
        public string File { get; set; }
        public string AppealStatus { get; set; }
        public string FormStatus { get; set; }
        public string FileStatus { get; set; }
    }
}
