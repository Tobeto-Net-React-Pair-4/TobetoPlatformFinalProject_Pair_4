using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Appeal.Responses;
using Business.Dtos.User.Responses;

namespace Business.Dtos.UserAppeal.Responses
{
    public class GetListUserAppealResponse
    {
        public Guid UserId { get; set; }
        public Guid AppealId { get; set; }
        public GetUserResponse User { get; set; }
        public GetAppealResponse Appeal { get; set; }
    }
}
