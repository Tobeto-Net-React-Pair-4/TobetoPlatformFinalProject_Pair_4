using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.UserSkill.Responses
{
    public class GetUserSkillResponse
    {
        public Guid UserId { get; set; }
        public Guid SkillId { get; set; }
    }
}
