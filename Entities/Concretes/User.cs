﻿using Core.Entities;

namespace Entities.Concretes
{
    public class User : Entity<Guid>
    {
        public List<Course> Courses { get; set; }
        public Appeal Appeal { get; set; }
        public Guid AppealId { get; set; } 
        public string? NationalityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? District { get; set; }
        public string? AddressDetails { get; set; }
        public string? AboutMe { get; set; }
        public string? Phone { get; set; }




    }
}
