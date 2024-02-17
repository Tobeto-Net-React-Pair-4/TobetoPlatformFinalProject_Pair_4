using AutoMapper;
using Business.Dtos.Favourite.Requests;
using Business.Dtos.Favourite.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class FavouriteMappingProfile : Profile
    {
        public FavouriteMappingProfile()
        {
            CreateMap<Favourite, CreateFavouriteRequest>().ReverseMap();

            CreateMap<Favourite, UpdateFavouriteRequest>().ReverseMap();
            CreateMap<Favourite, CreatedFavouriteResponse>().ReverseMap();
            CreateMap<Favourite, UpdatedFavouriteResponse>().ReverseMap();
            CreateMap<Favourite, DeletedFavouriteResponse>().ReverseMap();

            CreateMap<Favourite, GetFavouriteResponse>().ReverseMap();



            CreateMap<Favourite, GetListFavouriteResponse>().ReverseMap();
            CreateMap<Paginate<Favourite>, Paginate<GetListFavouriteResponse>>().ReverseMap();
        }
    }
}
