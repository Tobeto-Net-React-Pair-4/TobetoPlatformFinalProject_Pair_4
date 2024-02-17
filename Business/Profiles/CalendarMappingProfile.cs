using AutoMapper;
using Business.Dtos.Calendar.Responses;
using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class CalendarMappingProfile : Profile
    {
        public CalendarMappingProfile()
        {
            CreateMap<Calendar, CreateCalendarRequest>().ReverseMap();
            CreateMap<Calendar, UpdateCalendarRequest>().ReverseMap();

            CreateMap<Calendar, CreatedCalendarResponse>().ReverseMap();
            CreateMap<Calendar, UpdatedCalendarResponse>().ReverseMap();
            CreateMap<Calendar, DeletedCalendarResponse>().ReverseMap();
            CreateMap<Calendar, GetCalendarResponse>().ReverseMap();

            CreateMap<Calendar, GetListCalendarResponse>().ReverseMap();
            CreateMap<Paginate<Calendar>, Paginate<GetListCalendarResponse>>().ReverseMap();
        }
    }
}
