using Business.Dtos.Assignment.Requests;
using Business.Dtos.Assignment.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IAssignment
    {
        Task<Paginate<GetListAssignmentResponse>> GetListAsync();
        Task<CreatedAssignmentResponse> AddAsync(CreateAssignmentRequest createAssignmentRequest);
        Task<UpdatedAssignmentResponse> UpdateAsync(UpdateAssignmentRequest updateAssignmentRequest);
        Task<DeletedAssignmentResponse> DeleteAsync(Guid Id);
        Task<GetAssignmentResponse> GetByIdAsync(Guid Id);
    }
}
