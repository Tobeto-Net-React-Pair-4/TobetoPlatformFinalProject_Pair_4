using AutoMapper;
using Business.Dtos.Course.Responses;
using Business.Dtos.UserCourse.Requests;
using Business.Dtos.UserCourse.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

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
                .ForMember(destinationMember: us => us.User,
                           memberOptions: opt => opt.MapFrom(uc => uc.User))
                .ForMember(destinationMember: c => c.Course,
                           memberOptions: opt => opt.MapFrom(uc => uc.Course)).ReverseMap();
            CreateMap<Paginate<UserCourse>, Paginate<GetListUserCourseResponse>>().ReverseMap();

            CreateMap<UserCourse, GetListCourseResponse>()
                .IncludeMembers(uc => uc.Course)
                .ForMember(destinationMember: glcr => glcr.Id, memberOptions: opt => opt.MapFrom(c => c.CourseId))
                .ReverseMap();

            CreateMap<Paginate<UserCourse>, Paginate<GetListCourseResponse>>().ReverseMap();

        }
    }
}

