using Business.Abstracts;
using Business.Dtos.InstrutorSession.Responses;
using Business.Dtos.Session;
using Business.Dtos.Session.Requests;
using Business.Dtos.Session.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class SessionManager : ISessionService
    {
        public Task<CreatedSessionResponse> AddAsync(CreateSessionRequest createSessionRequest)
        {
            throw new NotImplementedException();
        }

        public Task<DeletedSessionResponse> DeleteAsync(Guid sessionId)
        {
            throw new NotImplementedException();
        }

        public Task<GetSessionResponse> GetByIdAsync(Guid sessionId)
        {
            throw new NotImplementedException();
        }

        public Task<CreatedInstructorSessionResponse> GetByIdAsync(CreatedInstructorSessionResponse createdInstructorSessionResponse)
        {
            throw new NotImplementedException();
        }

        public Task<Paginate<GetListSessionResponse>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UpdatedSessionResponse> UpdateAsync(UpdateSessionRequest updateSessionRequest)
        {
            throw new NotImplementedException();
        }
    }
}
