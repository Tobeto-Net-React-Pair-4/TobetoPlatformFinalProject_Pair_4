using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Like : Entity<Guid>
    {
        public int Count { get; set; }
        public Course Course { get; set; }
        public LiveContent LiveContent { get; set; }
        public AsyncContent AsyncContent { get; set; }

    }
}
