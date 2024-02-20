using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.CourseLiveContent.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.Liked.Requests;
using Business.Dtos.Liked.Responses;
using Business.Dtos.OperationClaim.Requests;
using Business.Dtos.OperationClaim.Responses;
using Business.Dtos.UserCourse.Responses;
using Business.Dtos.UserOperationClaim.Requests;
using Business.Dtos.UserOperationClaim.Responses;
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
        IUserOperationClaimService _userOperationClaimService;
        public OperationClaimManager(IMapper mapper, IOperationClaimDal operationClaimDal, IUserOperationClaimService userOperationClaimService)
        {
            _mapper = mapper;
            _operationClaimDal = operationClaimDal;
            _userOperationClaimService = userOperationClaimService;
        }

        //[SecuredOperation("admin")]
        public async Task<CreatedOperationClaimResponse> AddAsync(CreateOperationClaimRequest createOperationClaimRequest)
        {
            OperationClaim operationClaim = _mapper.Map<OperationClaim>(createOperationClaimRequest);
            var createdOperationClaimResponse = await _operationClaimDal.AddAsync(operationClaim);
            CreatedOperationClaimResponse result = _mapper.Map<CreatedOperationClaimResponse>(operationClaim);
            return result;
        }

        //[SecuredOperation("admin")]
        public async Task<CreatedUserOperationClaimResponse> AssignOperationClaimAsync(CreateUserOperationClaimRequest createUserOperationClaimRequest)
        {
            return await _userOperationClaimService.AddAsync(createUserOperationClaimRequest);
        }

        public async Task<DeletedOperationClaimResponse> DeleteAsync(DeleteOperationClaimRequest deleteOperationClaimRequest)
        {
            OperationClaim operationClaim = await _operationClaimDal.GetAsync(p => p.Id == deleteOperationClaimRequest.Id);
            await _operationClaimDal.DeleteAsync(operationClaim);
            return _mapper.Map<DeletedOperationClaimResponse>(operationClaim);

        }

        public async Task<GetOperationClaimResponse> GetByIdAsync(GetOperationClaimRequest getOperationClaimRequest)
        {
            var result = await _operationClaimDal.GetAsync(o => o.Id == getOperationClaimRequest.Id);
            return _mapper.Map<GetOperationClaimResponse>(result);
        }

        public async Task<Paginate<GetListOperationClaimResponse>> GetListAsync()
        {
            var data = await _operationClaimDal.GetListAsync();
            return _mapper.Map<Paginate<GetListOperationClaimResponse>>(data);
        }

        [SecuredOperation("admin")]
        public async Task<UpdatedOperationClaimResponse> UpdateAsync(UpdateOperationClaimRequest updateOperationClaimRequest)
        {
            OperationClaim operationClaim = await _operationClaimDal.GetAsync(p => p.Id == updateOperationClaimRequest.Id);
            _mapper.Map(updateOperationClaimRequest, operationClaim);
            operationClaim = await _operationClaimDal.UpdateAsync(operationClaim);
            return _mapper.Map<UpdatedOperationClaimResponse>(operationClaim);
        }
    }
}
