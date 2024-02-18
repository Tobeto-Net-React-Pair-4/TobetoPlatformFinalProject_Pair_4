using AutoMapper;
using Business.Dtos.CourseLikedByUser.Requests;
using Business.Dtos.CourseLikedByUser.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class CourseLikedByUserMappingProfile : Profile
    {
        public CourseLikedByUserMappingProfile()
        {
            CreateMap<CourseLikedByUser, CreateCourseLikedByUserRequest>().ReverseMap();
            CreateMap<CourseLikedByUser, DeleteCourseLikedByUserRequests>().ReverseMap();

            CreateMap<CourseLikedByUser, CreatedCourseLikedByUserResponse>().ReverseMap();
            CreateMap<CourseLikedByUser, DeletedCourseLikedByUserResponse>().ReverseMap();

            CreateMap<CourseLikedByUser, GetListCourseLikedByUserResponse>().ReverseMap();
            CreateMap<Paginate<CourseLikedByUser>, Paginate<GetListCourseLikedByUserResponse>>().ReverseMap();
        }
    }
}
