using Core.Entities.Concrete;
using System.Text.Json.Serialization;

namespace Entities.Concretes
{
    public class User : Entity<Guid>
    {
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
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }

        public ICollection<SocialMediaAccount> SocialMediaAccounts { get; set; }
        public ICollection<UserSurvey> UserSurveys { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; }
        public ICollection<UserAnnouncement> UserAnnouncements { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<Education> Educations { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<ForeignLanguage> ForeignLanguages { get; set; }
        public ICollection<UserOperationClaim> UserOperationsClaims { get; set; }
        public Appeal Appeal { get; set; }
        public PersonalInfo PersonalInfo { get; set; }

    }
}
