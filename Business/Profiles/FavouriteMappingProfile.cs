using AutoMapper;
using Business.Dtos.Content.Requests;
using Business.Dtos.Content.Responses;
using Business.Dtos.Favourite.Requests;
using Business.Dtos.Favourite.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class FavouriteMappingProfile : Profile
    {
        public FavouriteMappingProfile()
        {
            CreateMap<Favourite, CreateFavouriteRequest>().ReverseMap();
            CreateMap<Favourite, DeleteFavouriteRequest>().ReverseMap();
            CreateMap<Favourite, UpdateFavouriteRequest>().ReverseMap();
            CreateMap<Favourite, CreatedFavouriteResponse>().ReverseMap();
            CreateMap<Favourite, UpdatedFavouriteResponse>().ReverseMap();
            CreateMap<Favourite, DeletedFavouriteResponse>().ReverseMap();
            CreateMap<Favourite, GetFavouriteRequest>().ReverseMap();
            CreateMap<Favourite, GetFavouriteResponse>().ReverseMap();



            CreateMap<Favourite, GetListFavouriteResponse>().ReverseMap();
            CreateMap<Paginate<Favourite>, Paginate<GetListFavouriteResponse>>().ReverseMap();
        }
    }
}
