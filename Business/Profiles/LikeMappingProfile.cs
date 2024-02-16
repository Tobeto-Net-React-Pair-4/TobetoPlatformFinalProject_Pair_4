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
    public class LikeMappingProfile : Profile
    {
        public LikeMappingProfile()
        {
            CreateMap<Like, CreateLikeRequest>().ReverseMap();
            CreateMap<Like, DeleteLikeRequest>().ReverseMap();
            CreateMap<Like, UpdateLikeRequest>().ReverseMap();
            CreateMap<Like, CreatedLikeResponse>().ReverseMap();
            CreateMap<Like, UpdatedLikeResponse>().ReverseMap();
            CreateMap<Like, DeletedLikeResponse>().ReverseMap();
            CreateMap<Like, GetLikeRequest>().ReverseMap();
            CreateMap<Like, GetLikeResponse>().ReverseMap();



            CreateMap<Like, GetListLikeResponse>().ReverseMap();
            CreateMap<Paginate<Like>, Paginate<GetListLikeResponse>>().ReverseMap();
        }
    }
}
