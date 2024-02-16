using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System.Text.Json.Serialization;

namespace Entities.Concretes
{
    public class User : Entity<Guid>, IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }

        public PersonalInfo PersonalInfo { get; set; }
        public ICollection<File> Files { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<Education> Educations { get; set; }
        public ICollection<PasswordReset> PasswordResets { get; set; }

        public ICollection<SocialMediaAccount> SocialMediaAccounts { get; set; }
        public ICollection<UserSurvey> UserSurveys { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; }
        public ICollection<UserAppeal> UserAppeals { get; set; }
        public ICollection<UserAnnouncement> UserAnnouncements { get; set; }
        public ICollection<ForeignLanguage> ForeignLanguages { get; set; }
        public ICollection<UserOperationClaim> UserOperationsClaims { get; set; }
        public ICollection<UserExam> UserExams { get; set; }
        public ICollection<UserSkill> UserSkills { get; set; }
        public ICollection<UserCalendar> UserCalendars { get; set; }
        public ICollection<ContentLikedByUser> ContentLikedByUsers { get; set; }
        public ICollection<CourseFavouritedByUser> CourseFavouritedByUser { get; set; }
        public ICollection<CourseLikedByUser> CourseLikedByUsers { get; set; }




    }
}
