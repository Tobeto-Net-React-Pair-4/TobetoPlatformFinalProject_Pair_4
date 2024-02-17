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
            CreateMap<SocialMedia, CreateSocialMediaRequest>().ReverseMap();
            CreateMap<SocialMedia, DeleteSocialMediaRequest>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaRequest>().ReverseMap();
            CreateMap<SocialMedia, CreatedSocialMediaResponse>().ReverseMap();
            CreateMap<SocialMedia, UpdatedSocialMediaResponse>().ReverseMap();
            CreateMap<SocialMedia, DeletedSocialMediaResponse>().ReverseMap();

            CreateMap<SocialMedia, GetListSocialMediaResponse>().ReverseMap();
            CreateMap<Paginate<SocialMedia>, Paginate<GetListSocialMediaResponse>>().ReverseMap();
        }
    }
}
