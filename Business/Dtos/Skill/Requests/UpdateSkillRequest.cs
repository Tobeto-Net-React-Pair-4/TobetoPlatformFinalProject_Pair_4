﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Skill.Requests
{
    public class UpdateSkillRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
