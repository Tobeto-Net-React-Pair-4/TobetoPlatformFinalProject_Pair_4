using Business.Dtos.Announcement.Requests;
using Business.Dtos.OperationClaim.Requests;
using Business.Dtos.OperationClaim.Responses;
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

namespace Business.Abstracts
{
    public interface IOperationClaimService
    {
        Task<CreatedOperationClaimResponse> AddAsync(CreateOperationClaimRequest createOperationClaimRequest);
        Task<Paginate<GetListOperationClaimResponse>> GetListAsync();
        Task<DeletedOperationClaimResponse> DeleteAsync(Guid operationClaimId);
        Task<UpdatedOperationClaimResponse> UpdateAsync(UpdateOperationClaimRequest updateOperationClaimRequest);
        Task<GetOperationClaimResponse> GetByIdAsync(Guid operationClaimId);
        Task<CreatedUserOperationClaimResponse> AssignOperationClaimToUserAsync(CreateUserOperationClaimRequest createUserOperationClaimRequest);

    }
}
