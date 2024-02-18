using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.ContentLikedByUser.Requests
{
    public class DeleteContentLikedByUserRequest
    {
        public Guid UserId { get; set; }
        public Guid ContentId { get; set; }
    }
}
