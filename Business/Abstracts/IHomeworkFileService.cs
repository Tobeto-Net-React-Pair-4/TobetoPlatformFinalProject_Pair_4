using Business.Dtos.Homework.Requests;
using Business.Dtos.HomeworkFile.Responses;
using Business.Dtos.HomeworkFile.Requests;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Homework.Responses;
using Business.Dtos.Course.Responses;

namespace Business.Abstracts
{
    public interface IHomeworkFileService
    {
        Task<Paginate<GetListHomeworkResponse>> GetListAsync();
        Task<CreatedHomeworkFileResponse> AddAsync(CreateHomeworkFileRequest createHomeworkRequest);
        Task<DeletedHomeworkResponse> DeleteAsync(Guid homeworkId);
        Task<Paginate<GetListHomeworkResponse>> GetListByHomeworkIdAsync(Guid userId);




    }
}
