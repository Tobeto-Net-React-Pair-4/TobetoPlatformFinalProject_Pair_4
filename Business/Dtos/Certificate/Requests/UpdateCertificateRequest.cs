namespace Business.Dtos.Certificate.Requests
{
    public class UpdateCertificateRequest
    {
        public Guid Id { get; set; }
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }


    }
}
