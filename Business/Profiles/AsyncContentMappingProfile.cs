using AutoMapper;
using Business.Dtos.AsyncContent.Requests;
using Business.Dtos.AsyncContent.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class AsyncContentMappingProfile : Profile
    {
        public AsyncContentMappingProfile()
        {
            CreateMap<AsyncContent, CreateAsyncContentRequest>().ReverseMap();
            CreateMap<AsyncContent, UpdateAsyncContentRequest>().ReverseMap();

            CreateMap<AsyncContent, CreatedAsyncContentResponse>().ReverseMap();
            CreateMap<AsyncContent, UpdatedAsyncContentResponse>().ReverseMap();
            CreateMap<AsyncContent, DeletedAsyncContentResponse>().ReverseMap();
            CreateMap<AsyncContent, GetAsyncContentResponse>().ReverseMap();

            CreateMap<AsyncContent, GetListAsyncContentResponse>().ReverseMap();
            CreateMap<Paginate<AsyncContent>, Paginate<GetListAsyncContentResponse>>().ReverseMap();
        }
    }
}
