using AutoMapper;
using Business.Dtos.UserAppeal.Requests;
using Business.Dtos.UserAppeal.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class UserAppealMappingProfile : Profile
    {
        public UserAppealMappingProfile()
        {
            CreateMap<UserAppeal, CreateUserAppealRequest>().ReverseMap();
            CreateMap<UserAppeal, DeleteUserAppealRequest>().ReverseMap();
            CreateMap<UserAppeal, GetUserAppealRequest>().ReverseMap();

            CreateMap<UserAppeal, CreatedUserAppealResponse>().ReverseMap();
            CreateMap<UserAppeal, DeletedUserAppealResponse>().ReverseMap();
            CreateMap<UserAppeal, GetUserAppealResponse>().ReverseMap();
            CreateMap<UserAppeal, GetListUserAppealResponse>()
                    .ForMember(destinationMember: us => us.User, memberOptions: opt => opt.MapFrom(us => us.User))
                    .ForMember(destinationMember: c => c.Appeal, memberOptions: opt => opt.MapFrom(c => c.Appeal))
                    .ReverseMap();

            CreateMap<Paginate<UserAppeal>, Paginate<GetListUserAppealResponse>>().ReverseMap();
        }
    }
}
