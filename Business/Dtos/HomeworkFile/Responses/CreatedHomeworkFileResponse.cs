﻿using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.HomeworkFile.Responses
{
    public class CreatedHomeworkFileResponse
    {
        public Guid HomeworkId { get; set; }
        public Guid FileId { get; set; }
    }
}
