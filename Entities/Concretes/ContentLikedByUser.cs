using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class ContentLikedByUser:Entity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid ContentId { get; set; }
        
        public User User { get; set; }
        public LiveContent? LiveContent { get; set; }
        public AsyncContent? AsyncContent { get; set; }
    }
}
