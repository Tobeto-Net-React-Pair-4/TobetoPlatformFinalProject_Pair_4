using AutoMapper;
using Business.Dtos.CourseAsyncContent.Requests;
using Business.Dtos.CourseAsyncContent.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CourseAsyncContentMappingProfile : Profile
    {
        public CourseAsyncContentMappingProfile()
        {
            CreateMap<CourseAsyncContent, CreateCourseAsyncContentRequest>().ReverseMap();
            CreateMap<CourseAsyncContent, DeleteCourseAsyncContentRequest>().ReverseMap();

            CreateMap<CourseAsyncContent, CreatedCourseAsyncContentResponse>().ReverseMap();
            CreateMap<CourseAsyncContent, DeletedCourseAsyncContentResponse>().ReverseMap();

            CreateMap<CourseAsyncContent, GetListCourseAsyncContentResponse>().ReverseMap();
            CreateMap<Paginate<CourseAsyncContent>, Paginate<GetListCourseAsyncContentResponse>>().ReverseMap();
        }
    }
}
