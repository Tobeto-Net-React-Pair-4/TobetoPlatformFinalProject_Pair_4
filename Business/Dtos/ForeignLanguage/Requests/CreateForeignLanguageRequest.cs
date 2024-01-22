using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.ForeignLanguage.Requests
{
    public class CreateForeignLanguageRequest
    {
        public Guid UserId { get; set; } // User'ın ID'si
        public string LanguageList { get; set; }
        public string LanguageLevel { get; set; }
    }
}
