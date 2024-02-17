using Business.Dtos.Homework.Requests;
using Business.Dtos.Homework.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IHomeworkService
    {
        Task<Paginate<GetListHomeworkResponse>> GetListAsync();
        Task<CreatedHomeworkResponse> AddAsync(CreateHomeworkRequest createHomeworkRequest);
        Task<UpdatedHomeworkResponse> UpdateAsync(UpdateHomeworkRequest updateHomeworkRequest);
        Task<DeletedHomeworkResponse> DeleteAsync(Guid homeworkId);
        Task<GetHomeworkResponse> GetByIdAsync(Guid homeworkId);
    }
}
