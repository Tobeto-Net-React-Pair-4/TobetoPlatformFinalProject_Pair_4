using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Appeal : Entity<Guid>
    {
        public string Title { get; set; }
        public string Form { get; set; }
        public string File { get; set; }
        public string? AppealStatus { get; set; }
        public string? FormStatus { get; set; }
        public string? FileStatus { get; set; }
        public ICollection<UserAppeal> UserAppeals { get; set; }


    }
}
