using AutoMapper;
using Business.Dtos.UserCalendar.Requests;
using Business.Dtos.UserCalendar.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
