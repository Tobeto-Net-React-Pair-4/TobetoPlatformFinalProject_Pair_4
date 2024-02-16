using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Content : Entity<Guid>
    {
        public Guid CategoryId { get; set; }
        public Guid LikeId { get; set; }

        public string Name { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }

        //public int Score { get; set; }
        public Category Category { get; set; }
        public Like Like { get; set; }

        public ICollection<ContentLikedByUser> ContentLikedByUsers { get; set; }

    }
}
