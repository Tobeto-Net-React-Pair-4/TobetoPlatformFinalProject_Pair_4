using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.UserSurvey.Responses
{
    public class DeletedUserSurveyResponse
    {
        public Guid UserId { get; set; }
        public Guid SurveyId { get; set; }
    }
}
