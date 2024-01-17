using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<NorthwindContext>(options => options.UseInMemoryDatabase("nArchitecture"));
            services.AddDbContext<TobetoContext>(options => options.UseSqlServer(configuration.GetConnectionString("Tobeto")));


            services.AddScoped<IUserDal, EfUserDal>();
            services.AddScoped<ICourseDal, EfCourseDal>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<IInstructorDal, EfInstructorDal>();
            services.AddScoped<IUserDal, EfUserDal>();
            services.AddScoped<ISurveyDal, EfSurveyDal>();
            services.AddScoped<IUserSurveyDal, EfUserSurveyDal>();
            services.AddScoped<ICalendarEventDal, EfCalendarEventDal>();
            services.AddScoped<IUserCourseDal, EfUserCourseDal>();
            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
            services.AddScoped<IUserAnnouncementDal, EfUserAnnouncementDal>();
            services.AddScoped<IAppealDal, EfAppealDal>();
            services.AddScoped<IEducationDal, EfEducationDal>();

            return services;
        }
    }
}
