using AutoMapper;
using Business.Dtos.ForeignLanguage.Requests;
using Business.Dtos.ForeignLanguage.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class ForeignLanguageMappingProfile : Profile
    {
        public ForeignLanguageMappingProfile()
        {
            CreateMap<ForeignLanguage, CreateForeignLanguageRequest>().ReverseMap();
            CreateMap<ForeignLanguage, UpdateForeignLanguageRequest>().ReverseMap();


            CreateMap<ForeignLanguage, CreatedForeignLanguageResponse>().ReverseMap();
            CreateMap<ForeignLanguage, UpdatedForeignLanguageResponse>().ReverseMap();
            CreateMap<ForeignLanguage, DeletedForeignLanguageResponse>().ReverseMap();
            CreateMap<ForeignLanguage, GetByIdForeignLanguageResponse>().ReverseMap();


            CreateMap<ForeignLanguage, GetListForeignLanguageResponse>().ReverseMap();
            CreateMap<Paginate<ForeignLanguage>, Paginate<GetListForeignLanguageResponse>>().ReverseMap();
        }
    }
}
