﻿using Business.Abstracts;
using Business.Concretes;
using Core.Business.Rules;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICourseService, CourseManager>();
            services.AddScoped<IInstructorService, InstructorManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<ISurveyService, SurveyManager>();
            services.AddScoped<IUserSurveyService, UserSurveyManager>();
            services.AddScoped<ICalendarEventService, CalendarEventManager>();
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
            services.AddScoped<IExperinceService, ExperinceManager>();
            services.AddScoped<IForeignLanguageService, ForeignLanguageManager>();
            services.AddScoped<IEducationService, EducationManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<ITokenHelper, JwtHelper>();
            services.AddScoped<IOperationClaimService, OperationClaimManager>();
            services.AddScoped<ISkillService, SkillManager>();
            services.AddScoped<IUserSkillService, UserSkillManager>();

            return services;
        }
        public static IServiceCollection AddSubClassesOfType(
            this IServiceCollection services,
            Assembly assembly,
            Type type,
            Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
            )
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
                if (addWithLifeCycle == null)
                    services.AddScoped(item);

                else
                    addWithLifeCycle(services, type);
            return services;
        }
    }
}
