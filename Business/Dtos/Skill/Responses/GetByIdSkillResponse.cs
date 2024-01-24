using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Skill.Responses
{
    public class GetByIdSkillResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
