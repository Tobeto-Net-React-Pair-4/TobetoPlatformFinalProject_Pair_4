using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class PersonalInfo : Entity<Guid>
    {
        public Guid UserId { get; set; }
        public string? NationalityId { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string ImageUrl{ get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? AddressDetails { get; set; }
        public string? AboutMe { get; set; }
        public User User { get; set; }
    }
}