using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IInstructorService
    {
        Task<Paginate<GetListInstructorResponse>> GetListAsync();
        Task<CreatedInstructorResponse> AddAsync(CreateInstructorRequest createInstructorRequest);
        Task<UpdatedInstructorResponse> UpdateAsync(UpdateInstructorRequest updateInstructorRequest);
        Task<DeletedInstructorResponse> DeleteAsync(DeleteInstructorRequest deleteInstructorRequest);
        Task<GetByIdInstructorResponse> GetByIdAsync(Guid instructorId);
    }
}
