using AutoMapper;
using Business.Dtos.CourseLiveContent.Requests;
using Business.Dtos.CourseLiveContent.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CourseLiveContentMappingProfile : Profile
    {
        public CourseLiveContentMappingProfile()
        {
            CreateMap<CourseLiveContent, CreateCourseLiveContentRequest>().ReverseMap();
            CreateMap<CourseLiveContent, DeleteCourseLiveContentRequest>().ReverseMap();
            CreateMap<CourseLiveContent, GetCourseLiveContentRequest>().ReverseMap();
            CreateMap<CourseLiveContent, UpdateCourseLiveContentRequest>().ReverseMap();

            CreateMap<CourseLiveContent, CreatedCourseLiveContentResponse>().ReverseMap();
            CreateMap<CourseLiveContent, UpdatedCourseLiveContentResponse>().ReverseMap();
            CreateMap<CourseLiveContent, DeletedCourseLiveContentResponse>().ReverseMap();
            CreateMap<CourseLiveContent, GetCourseLiveContentResponse>().ReverseMap();


            CreateMap<CourseLiveContent, GetListCourseLiveContentResponse>().ReverseMap();
            CreateMap<Paginate<CourseLiveContent>, Paginate<GetListCourseLiveContentResponse>>().ReverseMap();
        }
    }
}
