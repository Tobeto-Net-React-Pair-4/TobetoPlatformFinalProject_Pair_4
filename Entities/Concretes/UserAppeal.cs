using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concretes
{
    public class UserAppeal : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid AppealId { get; set; }
        public Appeal Appeal { get; set; }
        public User User { get; set; }
    }
}
