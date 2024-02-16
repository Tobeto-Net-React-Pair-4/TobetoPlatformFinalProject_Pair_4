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
    public class CalendarMappingProfile : Profile
    {
        public CalendarMappingProfile()
        {
            CreateMap<Calendar, CreateCalendarRequest>().ReverseMap();
            CreateMap<Calendar, DeleteCalendarRequest>().ReverseMap();
            CreateMap<Calendar, UpdateCalendarRequest>().ReverseMap();
            CreateMap<Calendar, CreatedCalendarResponse>().ReverseMap();
            CreateMap<Calendar, UpdatedCalendarResponse>().ReverseMap();
            CreateMap<Calendar, DeletedCalendarResponse>().ReverseMap();

            CreateMap<Calendar, GetListCalendarResponse>().ReverseMap();
            CreateMap<Paginate<Calendar>, Paginate<GetListCalendarResponse>>().ReverseMap();
        }
    }
}
