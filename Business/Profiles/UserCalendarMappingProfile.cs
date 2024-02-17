using AutoMapper;
using Business.Dtos.UserCalendar;
using Business.Dtos.UserCalendar.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class UserCalendarMappingProfile : Profile
    {
        public UserCalendarMappingProfile()
        {
            CreateMap<UserCalendar, CreateUserCalendarRequest>().ReverseMap();
            CreateMap<UserCalendar, GetUserCalendarRequest>().ReverseMap();
            CreateMap<UserCalendar, UpdateUserCalendarRequest>().ReverseMap();
            CreateMap<UserCalendar, DeleteUserCalendarRequest>().ReverseMap();
            CreateMap<UserCalendar, UpdateUserCalendarRequest>().ReverseMap();

            CreateMap<UserCalendar, CreatedUserCalendarResponse>().ReverseMap();
            CreateMap<UserCalendar, UpdatedUserCalendarResponse>().ReverseMap();
            CreateMap<UserCalendar, DeletedUserCalendarResponse>().ReverseMap();
            CreateMap<UserCalendar, GetUserCalendarResponse>().ReverseMap();



            CreateMap<UserCalendar, GetListUserCalendarResponse>().ReverseMap();
            CreateMap<Paginate<UserCalendar>, Paginate<GetListUserCalendarResponse>>().ReverseMap();
        }
    }
}
