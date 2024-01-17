namespace Business.Dtos.Certificate.Responses
{
    public class GetCertificateResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
    }
}
