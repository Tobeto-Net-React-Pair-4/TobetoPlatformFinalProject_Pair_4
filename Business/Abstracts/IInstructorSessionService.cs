using Business.Dtos.InstrutorSession.Requests;
using Business.Dtos.InstrutorSession.Responses;
using Business.Dtos.Session.Responses;
using Core.DataAccess.Paging;


namespace Business.Abstracts
{
    public interface IInstructorSessionService
    {
        Task<Paginate<GetListInstructorSessionResponse>> GetListAsync();
        Task<CreatedInstructorSessionResponse> AddAsync(CreateInstructorSessionRequest createInstructorSessionRequest);
        Task<DeletedInstructorSessionResponse> DeleteAsync(DeleteInstructorSessionRequest deleteInstructorSessionRequest);
        Task<UpdatedInstructorSessionResponse> UpdateAsync(UpdateInstructorSessionRequest updateInstructorSessionRequest);
        Task<GetInstructorSessionResponse> GetByIdAsync(GetInstructorSessionRequest getInstructorSessionRequest);
        Task<Paginate<GetListSessionResponse>> GetListByInstructorIdAsync(Guid instructorId);
    }
}
