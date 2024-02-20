using AutoMapper;
using Business.Dtos.Experience.Requests;
using Business.Dtos.Experience.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ExperinceMappingProfile : Profile
    {
        public ExperinceMappingProfile()
        {
            CreateMap<Experience, CreateExperienceRequest>().ReverseMap();
            CreateMap<Experience, UpdateExperienceRequest>().ReverseMap();
            CreateMap<Experience, CreatedExperienceResponse>().ReverseMap();
            CreateMap<Experience, UpdatedExperienceResponse>().ReverseMap();
            CreateMap<Experience, DeletedExperienceResponse>().ReverseMap();

            CreateMap<Experience, GetListExperienceResponse>().ReverseMap();
            CreateMap<Paginate<Experience>, Paginate<GetListExperienceResponse>>().ReverseMap();
        }
    
    }
}
