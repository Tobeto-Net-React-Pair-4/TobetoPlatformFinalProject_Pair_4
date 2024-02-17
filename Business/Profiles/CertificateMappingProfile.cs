using AutoMapper;
using Business.Dtos.Certificate.Requests;
using Business.Dtos.Certificate.Responses;
using Business.Dtos.User.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class CertificateMappingProfile : Profile
    {
        public CertificateMappingProfile()
        {
            CreateMap<Certificate, CreateCertificateRequest>().ReverseMap();
            CreateMap<Certificate, UpdateCertificateRequest>().ReverseMap();
            CreateMap<Certificate, CreatedCertificateResponse>().ReverseMap();
            CreateMap<Certificate, UpdatedCertificateResponse>().ReverseMap();
            CreateMap<Certificate, DeletedCertificateResponse>().ReverseMap();
            CreateMap<Certificate, GetUserResponse>().ReverseMap();

            CreateMap<Certificate, GetListCertificateResponse>().ReverseMap();
            CreateMap<Certificate, GetByIdCertificateResponse>()
                    .ForMember(destinationMember: c => c.Users, memberOptions: opt => opt.MapFrom(c => c.User))
                    .ReverseMap();

            CreateMap<Paginate<Certificate>, Paginate<GetListCertificateResponse>>().ReverseMap();

        }

    }
}
