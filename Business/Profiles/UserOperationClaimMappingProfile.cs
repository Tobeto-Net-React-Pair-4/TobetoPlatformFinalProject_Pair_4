using AutoMapper;
using Business.Dtos.UserCourse.Responses;
using Business.Dtos.UserOperationClaim.Requests;
using Business.Dtos.UserOperationClaim.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class UserOperationClaimMappingProfile : Profile
    {
        public UserOperationClaimMappingProfile()
        {
            CreateMap<UserOperationClaim, CreateUserOperationClaimRequest>().ReverseMap();
            CreateMap<UserOperationClaim, CreatedUserOperationClaimResponse>().ReverseMap();
            CreateMap<UserOperationClaim, GetUserOperationClaimRequest>().ReverseMap();
            CreateMap<UserOperationClaim, GetUserOperationClaimResponse>().ReverseMap();


            CreateMap<UserOperationClaim, GetListUserOperationClaimResponse>()
                    .ForMember(
                destinationMember: us => us.User,
                memberOptions: opt => opt.MapFrom(uc => uc.User))
                .ForMember(
                destinationMember: c => c.OperationClaim,
                memberOptions: opt => opt.MapFrom(uc => uc.OperationClaim))
                .ReverseMap();

            CreateMap<Paginate<UserOperationClaim>, Paginate<GetListUserOperationClaimResponse>>().ReverseMap();



        }

    }
}
