using Business.Abstracts;
using Business.Concretes;
using Business.Rules;
using Core.Business.Rules;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICourseService, CourseManager>();
            services.AddScoped<IInstructorService, InstructorManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<ISurveyService, SurveyManager>();
            services.AddScoped<IUserSurveyService, UserSurveyManager>();
            services.AddScoped<ICalendarService, CalendarManager>();
            services.AddScoped<IUserCourseService, UserCourseManager>();
            services.AddScoped<ICertificateService, CertificateManager>();
            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IUserAnnouncementService, UserAnnouncementManager>();
            services.AddScoped<IAppealService, AppealManager>();
            services.AddScoped<IUserAppealService, UserAppealManager>();
            services.AddScoped<IUserExamService, UserExamManager>();
            services.AddScoped<IExamService, ExamManager>();
            services.AddScoped<IExamQuestionService, ExamQuestionManager>();
            services.AddScoped<IQuestionAnswerService, QuestionAnswerManager>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<IExperienceService, ExperienceManager>();
            services.AddScoped<IForeignLanguageService, ForeignLanguageManager>();
            services.AddScoped<IEducationService, EducationManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<ITokenHelper, JwtHelper>();
            services.AddScoped<IOperationClaimService, OperationClaimManager>();
            services.AddScoped<ISkillService, SkillManager>();
            services.AddScoped<IUserSkillService, UserSkillManager>();
            services.AddScoped<IPersonalInfoService, PersonalInfoManager>();
            services.AddScoped<ILikeService, LikeManager>();
            services.AddScoped<IFavouriteService, FavouriteManager>();
            services.AddScoped<IHomeworkService, HomeworkManager>();
            services.AddScoped<IHomeworkFileService, HomeworkFileManager>();
            services.AddScoped<IAssignmentService, AssignmentManager>();
            services.AddScoped<IAsyncContentService, AsyncContentManager>();
            services.AddScoped<IContentLikedByUserService, ContentLikedByUserManager>();
            services.AddScoped<ICourseAsyncContentService, CourseAsyncContentManager>();
            services.AddScoped<ICourseFavouritedByUserService,  CourseFavouritedByUserManager>();
            services.AddScoped<ICourseLikedByUserService, CourseLikedByUserManager>();
            services.AddScoped<ICourseLiveContentService, CourseLiveContentManager>();
            services.AddScoped<IFileService, FileManager>();
            services.AddScoped<IInstructorSessionService, InstructorSessionManager>();
            services.AddScoped<ILiveContentService, LiveContentManager>();
            services.AddScoped<IPasswordResetService, PasswordResetManager>();
            services.AddScoped<ISessionService, SessionManager>();
            services.AddScoped<IUserCalendarService, UserCalendarManager>();
            services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();


            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules<Entity<Guid>>));


            //Business Rules

            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<CategoryBusinessRules>();
            services.AddScoped<CourseBusinessRules>();
            services.AddScoped<SocialMediaBusinessRules>();
            services.AddScoped<ForeignLanguageBusinessRules>();
            //services.AddScoped<UserBusinessRules>();



            return services;
        }
        public static IServiceCollection AddSubClassesOfType(
            this IServiceCollection services,
            Assembly assembly,
            Type type,
            Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
            )
        {
            //var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            var types = assembly.GetTypes().Where(t => t.BaseType?.Name == type.Name && t != type).ToList();
            foreach (var item in types)
                if (addWithLifeCycle == null)
                    services.AddScoped(item);

                else
                    addWithLifeCycle(services, type);
            return services;
        }
    }
}
