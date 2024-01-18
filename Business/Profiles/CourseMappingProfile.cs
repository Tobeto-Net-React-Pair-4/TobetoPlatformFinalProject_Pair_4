using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Category.Responses;
using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
using Business.Dtos.User.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Course, CreateCourseRequest>().ReverseMap();
            CreateMap<Course, DeleteCourseRequest>().ReverseMap();
            CreateMap<Course, UpdateCourseRequest>().ReverseMap();
            CreateMap<Course, GetByIdCourseRequest>().ReverseMap();

            CreateMap<Course, CreatedCourseResponse>().ReverseMap();
            CreateMap<Course, UpdatedCourseResponse>().ReverseMap();
            CreateMap<Course, DeletedCourseResponse>().ReverseMap();
            CreateMap<Course, GetCourseResponse>().ReverseMap();


            CreateMap<Course, GetListCourseResponse>()
                .ForMember(destinationMember: p => p.CategoryName, memberOptions: opt => opt.MapFrom(p => p.Category.Name))
                .ForMember(destinationMember: c => c.InstructorName, memberOptions: opt => opt.MapFrom(c => c.Instructor.Name))
                .ReverseMap();

            CreateMap<Course, GetByIdCourseResponse>()
                .ForMember(destinationMember: u => u.Users, memberOptions: opt => opt.MapFrom(u => u.UserCourses))
                .ForMember(destinationMember: p => p.InstructorName, memberOptions: opt => opt.MapFrom(p => p.Instructor.Name))
                .ForMember(destinationMember: c => c.CategoryName, memberOptions: opt => opt.MapFrom(c => c.Category.Name))
                .ReverseMap();

            CreateMap<Paginate<Course>, Paginate<GetListCourseResponse>>().ReverseMap();
        }

    }
}
