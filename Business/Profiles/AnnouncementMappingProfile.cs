using AutoMapper;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class AnnouncementMappingProfile : Profile
    {
        public AnnouncementMappingProfile()
        {
                CreateMap<Announcement, CreateAnnouncementRequest>().ReverseMap();
                CreateMap<Announcement, DeleteAnnouncementRequest>().ReverseMap();
                CreateMap<Announcement, UpdateAnnouncementRequest>().ReverseMap();
                CreateMap<Announcement, CreatedAnnouncementResponse>().ReverseMap();
                CreateMap<Announcement, UpdatedAnnouncementResponse>().ReverseMap();
                CreateMap<Announcement, DeletedAnnouncementResponse>().ReverseMap();

                CreateMap<Announcement, GetListAnnouncementResponse>().ReverseMap();
                CreateMap<Paginate<Announcement>, Paginate<GetListAnnouncementResponse>>().ReverseMap();
        }
    }
}
