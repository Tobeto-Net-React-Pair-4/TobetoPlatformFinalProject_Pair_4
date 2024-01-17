using AutoMapper;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.Appeal.Requests;
using Business.Dtos.Appeal.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class AppealMappingProfile : Profile
    {
        public AppealMappingProfile()
        {
            CreateMap<Appeal, CreateAppealRequest>().ReverseMap();
            CreateMap<Appeal, DeleteAppealRequest>().ReverseMap();
            CreateMap<Appeal, UpdateAppealRequest>().ReverseMap();
            CreateMap<Appeal, CreatedAppealResponse>().ReverseMap();
            CreateMap<Appeal, UpdatedAppealResponse>().ReverseMap();
            CreateMap<Appeal, DeletedAppealResponse>().ReverseMap();
            CreateMap<Appeal, GetAppealResponse>().ReverseMap();

            CreateMap<Appeal, GetListAppealResponse>().ReverseMap();
            CreateMap<Paginate<Appeal>, Paginate<GetListAppealResponse>>().ReverseMap();
        }
    }
}
