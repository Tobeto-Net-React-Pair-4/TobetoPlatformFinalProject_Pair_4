namespace Business.Dtos.ForeignLanguage.Requests
{
    public class GetByNameForeignLanguageRequest
    {
        public Guid Id { get; set; }
        public string LanguageList { get; set; }
    }
}
