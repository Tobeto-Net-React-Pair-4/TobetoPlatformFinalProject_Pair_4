using AutoMapper;
using Business.Dtos.PasswordReset.Requests;
using Business.Dtos.PasswordReset.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class PasswordResetMappingProfile : Profile
    {
        public PasswordResetMappingProfile()
        {
            CreateMap<PasswordReset, CreatePasswordResetRequest>().ReverseMap();
            CreateMap<PasswordReset, UpdatePasswordResetRequest>().ReverseMap();

            CreateMap<PasswordReset, CreatedPasswordResetResponse>().ReverseMap();
            CreateMap<PasswordReset, UpdatedPasswordResetResponse>().ReverseMap();
            CreateMap<PasswordReset, DeletedPasswordResetResponse>().ReverseMap();
            CreateMap<PasswordReset, GetPasswordResetResponse>().ReverseMap();

            CreateMap<PasswordReset, GetListPasswordResetResponse>().ReverseMap();
            CreateMap<Paginate<PasswordReset>, Paginate<GetListPasswordResetResponse>>().ReverseMap();
        }
    }
}
