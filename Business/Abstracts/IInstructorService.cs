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
        Task<Paginate<GetListedInstructorResponse>> GetListAsync();
        Task<CreatedInstructorResponse> Add(CreateInstructorRequest createInstructorRequest);
        Task<UpdatedInstructorResponse> Update(UpdateInstructorRequest updateInstructorRequest);
        Task<DeletedInstructorResponse> Delete(DeleteInstructorRequest deleteInstructorRequest);
    }
}
