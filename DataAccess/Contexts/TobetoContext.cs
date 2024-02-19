using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using File = Entities.Concretes.File;

namespace DataAccess.Contexts
{
    public class TobetoContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Appeal> Appeals { get; set; }
        public DbSet<AsyncContent> AsyncContents { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        public DbSet<SocialMedia> SocialMediaAccounts { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<ForeignLanguage> ForeignLanguages{ get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<UserExam> UserExams { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<HomeworkFile> HomeworkFiles { get; set; }
        public DbSet<InstructorSession> InstructorSessions { get; set; }
        public DbSet<LiveContent> LiveContents { get; set; }
        public DbSet<PasswordReset> PasswordResets { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<ContentLikedByUser> ContentLikedByUsers { get; set; }
        public DbSet<CourseFavouritedByUser> CourseFavouritedByUsers { get; set; }
        public DbSet<CourseAsyncContent> CourseAsyncContents { get; set; }
        public DbSet<CourseLiveContent> CourseLiveContents { get; set; }
        public DbSet<CourseLikedByUser> CourseLikedByUsers { get; set; }
        public DbSet<UserSurvey> UserSurveys { get; set; }
        public DbSet<UserAppeal> UserAppeals { get; set; }
        public DbSet<UserCalendar> UserCalendars { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<UserAnnouncement> UserAnnouncements { get; set; }
        public DbSet<UserOperationClaim> UserOperationsClaims { get; set; }
        public TobetoContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
