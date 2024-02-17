﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Favourite : Entity<Guid>
    {
        public Guid CourseId { get; set; }
        public int Count { get; set; }
        public Course Course { get; set; }

    }
}
