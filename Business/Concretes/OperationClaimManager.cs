using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.OperationClaim.Requests;
using Business.Dtos.OperationClaim.Responses;
using Business.Dtos.UserCourse.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class OperationClaimManager : IOperationClaimService
    {
        IMapper _mapper;
        IOperationClaimDal _operationClaimDal;
        public OperationClaimManager(IMapper mapper, IOperationClaimDal operationClaimDal)
        {
            _mapper = mapper;
            _operationClaimDal = operationClaimDal;
        }
        public async Task<CreatedOperationClaimResponse> AddAsync(CreateOperationClaimRequest createOperationClaimRequest)
        {
            OperationClaim operationClaim = _mapper.Map<OperationClaim>(createOperationClaimRequest);
            var createdOperationClaimResponse = await _operationClaimDal.AddAsync(operationClaim);
            CreatedOperationClaimResponse result = _mapper.Map<CreatedOperationClaimResponse>(operationClaim);
            return result;
        }

        public async Task<Paginate<GetListOperationClaimResponse>> GetListAsync()
        {
            var data = await _operationClaimDal.GetListAsync();
            return _mapper.Map<Paginate<GetListOperationClaimResponse>>(data);
        }
    }
}
