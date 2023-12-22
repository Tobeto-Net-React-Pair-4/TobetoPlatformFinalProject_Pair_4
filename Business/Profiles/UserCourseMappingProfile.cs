using AutoMapper;
using Business.Dtos.User.Responses;
using Business.Dtos.UserCourse.Requests;
using Business.Dtos.UserCourse.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class UserCourseMappingProfile : Profile
    {
        public UserCourseMappingProfile()
        {
            CreateMap<UserCourse, CreateUserCourseRequest>().ReverseMap();
            CreateMap<UserCourse, DeleteUserCourseRequest>().ReverseMap();
            CreateMap<UserCourse, GetUserCourseRequest>().ReverseMap();

            CreateMap<UserCourse, CreatedUserCourseResponse>().ReverseMap();
            CreateMap<UserCourse, DeletedUserCourseResponse>().ReverseMap();
            CreateMap<UserCourse, GetUserCourseResponse>().ReverseMap();
            CreateMap<UserCourse, GetListUserCourseResponse>()
                .ForMember(destinationMember: us => us.User, memberOptions: opt => opt.MapFrom(us => us.User))
                .ForMember(destinationMember: c => c.Course, memberOptions: opt => opt.MapFrom(c => c.Course))
                .ReverseMap();

            CreateMap<Paginate<UserCourse>, Paginate<GetListUserCourseResponse>>().ReverseMap();


        }
    }
}

