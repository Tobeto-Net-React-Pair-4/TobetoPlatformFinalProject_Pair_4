using Business.Abstracts;
using Business.Dtos.InstrutorSession.Requests;
using Business.Dtos.InstrutorSession.Responses;
using Business.Dtos.Session.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class InstructorSessionManager : IInstructorSessionService
    {
        public Task<CreatedInstructorSessionResponse> AddAsync(CreateInstructorSessionRequest createInstructorSessionRequest)
        {
            throw new NotImplementedException();
        }

        public Task<DeletedInstructorSessionResponse> DeleteAsync(DeleteInstructorSessionRequest deleteInstructorSessionRequest)
        {
            throw new NotImplementedException();
        }

        public Task<GetInstructorSessionResponse> GetByIdAsync(GetInstructorSessionRequest getInstructorSessionRequest)
        {
            throw new NotImplementedException();
        }

        public Task<Paginate<GetListInstructorSessionResponse>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Paginate<GetListSessionResponse>> GetListByInstructorIdAsync(Guid instructorId)
        {
            throw new NotImplementedException();
        }

        public Task<UpdatedInstructorSessionResponse> UpdateAsync(UpdateInstructorSessionRequest updateInstructorSessionRequest)
        {
            throw new NotImplementedException();
        }
    }
}
