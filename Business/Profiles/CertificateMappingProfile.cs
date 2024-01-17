using AutoMapper;
using Business.Dtos.Certificate.Requests;
using Business.Dtos.Certificate.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class CertificateMappingProfile : Profile
    {
        public CertificateMappingProfile()
        {
            CreateMap<Certificate, CreateCertificateRequest>().ForMember(destinationMember: c => c.UserID, memberOptions: opt => opt.MapFrom(c => c.User.Id)).ReverseMap();
            CreateMap<Certificate, DeleteCertificateRequest>().ReverseMap();
            CreateMap<Certificate, UpdateCertificateRequest>().ReverseMap();
            CreateMap<Certificate, GetByIdCertificateRequest>().ReverseMap();
            CreateMap<Certificate, CreatedCertificateResponse>().ReverseMap();
            CreateMap<Certificate, UpdatedCertificateResponse>().ReverseMap();
            CreateMap<Certificate, DeletedCertificateResponse>().ReverseMap();

            CreateMap<Certificate, GetListCertificateResponse>().ReverseMap();
            //CreateMap<Certificate, GetByIdCertificateResponse>()
            //        .ForMember(destinationMember: c => c.Users, memberOptions: opt => opt.MapFrom(c => c.User))
            //        .ReverseMap();

            CreateMap<Paginate<Certificate>, Paginate<GetListCertificateResponse>>().ReverseMap();

        }

    }
}
