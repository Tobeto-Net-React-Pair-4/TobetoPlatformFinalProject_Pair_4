using Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Skill : Entity<Guid>
    {
        public string Name { get; set; }
        public ICollection<UserSkill> UserSkills { get; set; }      

    }
}
