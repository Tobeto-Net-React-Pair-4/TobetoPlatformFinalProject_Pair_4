using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Announcement : Entity<Guid>
    {
        public string Title { get; set; }
        public string OrganizationName { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }

        public ICollection<UserAnnouncement> UserAnnouncements { get; set; }
    }
}
