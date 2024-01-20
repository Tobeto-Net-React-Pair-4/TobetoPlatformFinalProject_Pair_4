using Business.Dtos.User.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.ForeignLanguage.Responses
{
    public class GetListForeignLanguageResponse
    {
        public Guid Id { get; set; }
        public GetUserResponse User { get; set; }
        public string LanguageList { get; set; }
        public string LanguageLevel { get; set; }
    }
}
