using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.UserAnnouncement.Responses
{
    public class UpdatedUserAnnouncementResponse
    {
        public Guid UserId { get; set; }
        public Guid AnnouncementId { get; set; }
    }
}
