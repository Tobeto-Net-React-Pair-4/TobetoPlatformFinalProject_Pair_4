using AutoMapper;
using Business.Dtos.Content.Requests;
using Business.Dtos.Content.Responses;
using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ContentMappingProfile : Profile
    {
        public ContentMappingProfile()
        {
            CreateMap<Content, CreateContentRequest>().ReverseMap();
            CreateMap<Content, UpdateContentRequest>().ReverseMap();

            CreateMap<Content, CreatedContentResponse>().ReverseMap();
            CreateMap<Content, UpdatedContentResponse>().ReverseMap();

            CreateMap<Content, DeletedContentResponse>().ReverseMap();
            CreateMap<Content, GetContentResponse>().ReverseMap();
            CreateMap<Content, GetListContentResponse>().ReverseMap();
            CreateMap<Paginate<Content>, Paginate<GetListContentResponse>>().ReverseMap();
        }
    }
}
