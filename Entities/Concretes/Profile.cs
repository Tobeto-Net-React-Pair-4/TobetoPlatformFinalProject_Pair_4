using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Profile : Entity<Guid>
    {
        public User user { get; set; }
        public DateTime BirthDate { get; set; }
        public string NationalityId { get; set; }
        public string Country {  get; set; }
        public string City { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}
