using AutoMapper;
using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CalendarEventMappingProfile : Profile
    {
        public CalendarEventMappingProfile()
        {
            CreateMap<CalendarEvent, CreateCalendarEventRequest>().ReverseMap();
            CreateMap<CalendarEvent, DeleteCalendarEventRequest>().ReverseMap();
            CreateMap<CalendarEvent, UpdateCalendarEventRequest>().ReverseMap();
            CreateMap<CalendarEvent, CreatedCalendarEventResponse>().ReverseMap();
            CreateMap<CalendarEvent, UpdatedCalendarEventResponse>().ReverseMap();
            CreateMap<CalendarEvent, DeletedCalendarEventResponse>().ReverseMap();

            CreateMap<CalendarEvent, GetListCalendarEventResponse>().ReverseMap();
            CreateMap<Paginate<CalendarEvent>, Paginate<GetListCalendarEventResponse>>().ReverseMap();
        }
    }
}
