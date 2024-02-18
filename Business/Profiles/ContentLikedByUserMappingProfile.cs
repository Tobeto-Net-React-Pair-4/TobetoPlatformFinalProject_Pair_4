using AutoMapper;
using Business.Dtos.ContentLikedByUser.Response;
using Business.Dtos.ContentLikedByUser.Requests;

using Core.DataAccess.Paging;
using Entities.Concretes;


namespace Business.Profiles
{
    public class ContentLikedByUserMappingProfile : Profile
    {
        public ContentLikedByUserMappingProfile()
        {
            CreateMap<ContentLikedByUser, CreateContentLikedByUserRequest>().ReverseMap();
            CreateMap<ContentLikedByUser, UpdateContentLikedByUserRequest>().ReverseMap();
            CreateMap<ContentLikedByUser, DeleteContentLikedByUserRequest>().ReverseMap();

            CreateMap<ContentLikedByUser, CreatedContentLikedByUserResponse>().ReverseMap();
            CreateMap<ContentLikedByUser, UpdatedContentLikedByUserResponse>().ReverseMap();
            CreateMap<ContentLikedByUser, DeletedContentLikedByUserResponse>().ReverseMap();
            CreateMap<ContentLikedByUser, GetContentLikedByUserResponse>().ReverseMap();

            CreateMap<ContentLikedByUser, GetListContentLikedByUserResponse>().ReverseMap();
            CreateMap<Paginate<ContentLikedByUser>, Paginate<GetListContentLikedByUserResponse>>().ReverseMap();
        }
    }
}
