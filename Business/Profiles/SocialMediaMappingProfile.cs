using AutoMapper;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.SocialMediaAccount.Requests;
using Business.Dtos.SocialMediaAccount.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class SocialMediaMappingProfile : Profile
    {
        public SocialMediaMappingProfile()
        {
            CreateMap<SocialMediaAccount, CreateSocialMediaRequest>().ReverseMap();
            CreateMap<SocialMediaAccount, DeleteSocialMediaRequest>().ReverseMap();
            CreateMap<SocialMediaAccount, UpdateSocialMediaRequest>().ReverseMap();
            CreateMap<SocialMediaAccount, CreatedSocialMediaResponse>().ReverseMap();
            CreateMap<SocialMediaAccount, UpdatedSocialMediaResponse>().ReverseMap();
            CreateMap<SocialMediaAccount, DeletedSocialMediaResponse>().ReverseMap();

            CreateMap<SocialMediaAccount, GetListSocialMediaResponse>().ReverseMap();
            CreateMap<Paginate<SocialMediaAccount>, Paginate<GetListSocialMediaResponse>>().ReverseMap();
        }
    }
}
