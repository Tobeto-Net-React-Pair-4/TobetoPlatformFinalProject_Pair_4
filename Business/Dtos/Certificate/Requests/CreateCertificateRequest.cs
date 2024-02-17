namespace Business.Dtos.Certificate.Requests
{
    public class CreateCertificateRequest
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }

    }
}
