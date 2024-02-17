using AutoMapper;
using Business.Dtos.Education.Requests;
using Business.Dtos.Education.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class EducationMappingProfile : Profile  
    {
        public EducationMappingProfile()
        {
            CreateMap<Education, CreateEducationRequest>().ReverseMap();
            CreateMap<Education, CreatedEducationResponse>().ReverseMap();
            CreateMap<Education, GetEducationResponse>().ReverseMap();
            CreateMap<Education, GetByIdEducationResponse>().ReverseMap();
            CreateMap<Education, UpdateEducationRequest>().ReverseMap();
            CreateMap<Education, UpdatedEducationResponse>().ReverseMap();
            CreateMap<Education, DeletedEducationResponse>().ReverseMap();

            CreateMap<Paginate<Education>, Paginate<GetListEducationResponse>>().ReverseMap();
            CreateMap<Education, GetListEducationResponse>().ReverseMap();

        }
    }
}
