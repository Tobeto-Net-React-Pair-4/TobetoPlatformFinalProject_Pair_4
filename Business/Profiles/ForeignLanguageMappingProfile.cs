using AutoMapper;
using Business.Dtos.Experience.Requests;
using Business.Dtos.Experience.Responses;
using Business.Dtos.ForeignLanguage.Requests;
using Business.Dtos.ForeignLanguage.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ForeignLanguageMappingProfile : Profile
    {
        public ForeignLanguageMappingProfile()
        {
            CreateMap<ForeignLanguage, CreateForeignLanguageRequest>().ReverseMap();
            CreateMap<ForeignLanguage, DeleteForeignLanguageRequest>().ReverseMap();
            CreateMap<ForeignLanguage, UpdateForeignLanguageRequest>().ReverseMap();
            CreateMap<ForeignLanguage, CreatedForeignLanguageResponse>().ReverseMap();
            CreateMap<ForeignLanguage, UpdatedForeignLanguageResponse>().ReverseMap();
            CreateMap<ForeignLanguage, DeletedForeignLanguageResponse>().ReverseMap();

            CreateMap<ForeignLanguage, GetListForeignLanguageResponse>().ReverseMap();
            CreateMap<Paginate<ForeignLanguage>, Paginate<GetListForeignLanguageResponse>>().ReverseMap();
        }
    }
}
