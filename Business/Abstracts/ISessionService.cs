using Business.Dtos.InstrutorSession.Responses;
using Business.Dtos.Session.Requests;
using Business.Dtos.Session.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ISessionService
    {
        Task<Paginate<GetListSessionResponse>> GetListAsync();
        Task<CreatedSessionResponse> AddAsync(CreateSessionRequest createSessionRequest);
        Task<UpdatedSessionResponse> UpdateAsync(UpdateSessionRequest updateSessionRequest);
        Task<DeletedSessionResponse> DeleteAsync(Guid sessionId);
        Task<GetSessionResponse> GetByIdAsync(Guid sessionId);
        Task<CreatedInstructorSessionResponse> GetByIdAsync(CreatedInstructorSessionResponse createdInstructorSessionResponse);


    }
}
