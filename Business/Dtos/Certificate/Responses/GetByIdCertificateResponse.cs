namespace Business.Dtos.Certificate.Responses
{
    public class GetByIdCertificateResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        //public GetUserResponse User { get; set; }
    }
}
