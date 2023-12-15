using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
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
            CreateMap<Course, CreatedCourseResponse>().ReverseMap();
            CreateMap<Course, UpdatedCourseResponse>().ReverseMap();
            CreateMap<Course, DeletedCourseResponse>().ReverseMap();

            CreateMap<Course, GetListedCourseResponse>()
                .ForMember(destinationMember: p => p.CategoryName, memberOptions: opt => opt.MapFrom(p => p.Category.Name)).ReverseMap();
            CreateMap<Course, GetListedCourseResponse>()
                .ForMember(destinationMember: c => c.InstructorName, memberOptions: opt => opt.MapFrom(c => c.Instructor.InstructorName)).ReverseMap();
            CreateMap<Paginate<Course>, Paginate<GetListedCourseResponse>>().ReverseMap();
        }
    }
}
