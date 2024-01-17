using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.UserAppeal.Responses
{
    public class GetUserAppealResponse
    {
        //public Guid Id { get; set; }
        public Guid UserId { get; set; }  // GEREK VAR MI?
        public Guid CourseId { get; set; }

        //public ICollection<GetListUserResponse> Users { get; set; }
    }
}
