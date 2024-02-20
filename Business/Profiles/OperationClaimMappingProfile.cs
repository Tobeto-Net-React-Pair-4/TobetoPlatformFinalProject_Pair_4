using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.OperationClaim.Requests;
using Business.Dtos.OperationClaim.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Profiles
{
    public class OperationClaimMappingProfile : Profile
    {
        public OperationClaimMappingProfile()
        {

            CreateMap<OperationClaim, CreateOperationClaimRequest>().ReverseMap();
            CreateMap<OperationClaim, CreatedOperationClaimResponse>().ReverseMap();
            CreateMap<OperationClaim, UpdateOperationClaimRequest>().ReverseMap();
            CreateMap<OperationClaim, UpdatedOperationClaimResponse>().ReverseMap();
            CreateMap<OperationClaim, DeleteOperationClaimRequest>().ReverseMap();
            CreateMap<OperationClaim, DeletedOperationClaimResponse>().ReverseMap();
            CreateMap<Paginate<OperationClaim>, Paginate<GetListOperationClaimResponse>>().ReverseMap();
            CreateMap<OperationClaim, GetListOperationClaimResponse>().ReverseMap();
            CreateMap<OperationClaim, GetListOperationClaimResponse>().ReverseMap();

        }
    }
}
