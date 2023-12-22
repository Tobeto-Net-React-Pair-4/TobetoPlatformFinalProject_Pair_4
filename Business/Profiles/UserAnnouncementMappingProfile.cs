using AutoMapper;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.UserAnnouncement.Requests;
using Business.Dtos.UserAnnouncement.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class UserAnnouncementMappingProfile : Profile
    {
        public UserAnnouncementMappingProfile() {

            CreateMap<UserAnnouncement, CreateUserAnnouncementRequest>().ReverseMap();
            CreateMap<UserAnnouncement, DeleteUserAnnouncementRequest>().ReverseMap();
            CreateMap<UserAnnouncement, UpdateUserAnnouncementRequest>().ReverseMap();
            CreateMap<UserAnnouncement, CreatedUserAnnouncementResponse>().ReverseMap();
            CreateMap<UserAnnouncement, UpdatedUserAnnouncementResponse>().ReverseMap();
            CreateMap<UserAnnouncement, DeletedUserAnnouncementResponse>().ReverseMap();

            CreateMap<UserAnnouncement, GetListUserAnnouncementResponse>().ReverseMap();
            CreateMap<Paginate<UserAnnouncement>, Paginate<GetListUserAnnouncementResponse>>().ReverseMap();




        }
    }
}
