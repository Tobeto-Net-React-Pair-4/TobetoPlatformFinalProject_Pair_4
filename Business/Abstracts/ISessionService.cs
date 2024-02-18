using Business.Dtos.InstrutorSession.Requests;
using Business.Dtos.InstrutorSession.Responses;
using Business.Dtos.Session;
using Business.Dtos.Session.Requests;
using Business.Dtos.Session.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface ISessionService
    {
        Task<Paginate<GetListSessionResponse>> GetListAsync();
        Task<CreatedSessionResponse> AddAsync(CreateSessionRequest createSessionRequest);
        Task<DeletedSessionResponse> DeleteAsync(Guid sessionId);
        Task<UpdatedSessionResponse> UpdateAsync(UpdateSessionRequest updateSessionRequest);
        Task<GetSessionResponse> GetByIdAsync(Guid sessionId);
        Task<Paginate<GetListSessionResponse>> GetListByInstructorIdAsync(Guid instructorId);
        Task<CreatedInstructorSessionResponse> AssignSessionAsync(CreateInstructorSessionRequest createInstructorSessionRequest);


    }
}
