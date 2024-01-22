using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class UserAnnouncement : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid AnnouncementId { get; set; }
        public User User { get; set; }
        public Announcement Announcement { get; set; }
    }
}
