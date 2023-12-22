using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Announcement.Requests
{
    public class CreateAnnouncementRequest
    {
        public string Title { get; set; }
        public string OrganizationName { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
    }
}
