using Business.Dtos.User.Responses;

namespace Business.Dtos.ForeignLanguage.Responses
{
    public class GetByNameForeignLanguageResponse
    {
        public Guid Id { get; set; }
        public GetUserResponse User { get; set; }
        public string LanguageList { get; set; }
        public string LanguageLevel { get; set; }

    }
}
