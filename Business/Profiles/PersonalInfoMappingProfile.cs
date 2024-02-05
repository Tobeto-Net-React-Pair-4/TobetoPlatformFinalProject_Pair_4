using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.PersonalInfo.Requests;
using Business.Dtos.PersonalInfo.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class PersonalInfoMappingProfile : Profile
    {
        public PersonalInfoMappingProfile()
        {
            CreateMap<PersonalInfo, CreatePersonalInfoRequest>().ReverseMap();
            CreateMap<PersonalInfo, DeletePersonalInfoRequest>().ReverseMap();
            CreateMap<PersonalInfo, UpdatePersonalInfoRequest>().ReverseMap();
            CreateMap<PersonalInfo, GetPersonalInfoRequest>().ReverseMap();

            CreateMap<PersonalInfo, CreatedPersonalInfoResponse>().ReverseMap();
            CreateMap<PersonalInfo, UpdatedPersonalInfoResponse>().ReverseMap();
            CreateMap<PersonalInfo, DeletedPersonalInfoResponse>().ReverseMap();
            CreateMap<PersonalInfo, GetPersonalInfoResponse>()
                .ForMember(destinationMember: p => p.FirstName, memberOptions: opt => opt.MapFrom(u => u.User.FirstName))
                .ForMember(destinationMember: p => p.LastName, memberOptions: opt => opt.MapFrom(u => u.User.LastName))
                .ReverseMap();

            CreateMap<PersonalInfo, GetListPersonalInfoResponse>().ReverseMap();
            CreateMap<Paginate<PersonalInfo>, Paginate<GetListPersonalInfoResponse>>().ReverseMap();
        }
    }
}
