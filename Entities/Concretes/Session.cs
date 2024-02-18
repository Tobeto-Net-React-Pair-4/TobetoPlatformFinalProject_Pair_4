﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Session:Entity<Guid>
    {
        public Guid LiveContentId { get; set; }
        public string RecordUrl { get; set; }
        public string SessionUrl { get; set; }
        public DateTime StartOfTime { get; set; }
        public DateTime EndOfTime { get; set; }
        public LiveContent LiveContent { get; set; }

        public ICollection<InstructorSession> InstructorSessions { get; set; }
    }
}
