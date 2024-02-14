using AutoMapper;
using Business.Dtos.Content.Requests;
using Business.Dtos.Content.Responses;
using Business.Dtos.Liked.Requests;
using Business.Dtos.Liked.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class LikedMappingProfile : Profile
    {
        public LikedMappingProfile()
        {
            CreateMap<Liked, CreateLikedRequest>().ReverseMap();
            CreateMap<Liked, DeleteLikedRequest>().ReverseMap();
            CreateMap<Liked, UpdateLikedRequest>().ReverseMap();
            CreateMap<Liked, CreatedLikedResponse>().ReverseMap();
            CreateMap<Liked, UpdatedLikedResponse>().ReverseMap();
            CreateMap<Liked, DeletedLikedResponse>().ReverseMap();
            CreateMap<Liked, GetLikedRequest>().ReverseMap();
            CreateMap<Liked, GetLikedResponse>().ReverseMap();



            CreateMap<Liked, GetListLikedResponse>().ReverseMap();
            CreateMap<Paginate<Liked>, Paginate<GetListLikedResponse>>().ReverseMap();
        }
    }
}
