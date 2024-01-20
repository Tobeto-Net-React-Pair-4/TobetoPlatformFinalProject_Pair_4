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
            CreateMap<Experience, CreateExperinceRequest>().ReverseMap();
            CreateMap<Experience, DeleteExperinceRequest>().ReverseMap();
            CreateMap<Experience, UpdateExperinceRequest>().ReverseMap();
            CreateMap<Experience, CreatedExperinceResponse>().ReverseMap();
            CreateMap<Experience, UpdatedExperinceResponse>().ReverseMap();
            CreateMap<Experience, DeletedExperinceResponse>().ReverseMap();

            CreateMap<Experience, GetListExperienceResponse>().ReverseMap();
            CreateMap<Paginate<Experience>, Paginate<GetListExperienceResponse>>().ReverseMap();
        }
    
    }
}
