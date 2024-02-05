using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.OperationClaim.Requests;
using Business.Dtos.OperationClaim.Responses;
using Entities.Concretes;

namespace Business.Profiles
{
    public class OperationClaimMappingProfile : Profile
    {
        public OperationClaimMappingProfile()
        {
            CreateMap<OperationClaim, CreateOperationClaimRequest>().ReverseMap();
            CreateMap<OperationClaim, CreatedOperationClaimResponse>().ReverseMap();
        }
    }
}
