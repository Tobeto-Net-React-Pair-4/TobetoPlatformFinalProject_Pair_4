using Business.Abstracts;
using Business.Concretes;
using Core.Business.Rules;
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
