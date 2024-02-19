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
using Business.Dtos.File.Responses;

namespace Business.Abstracts
{
    public interface IHomeworkFileService
    {
        Task<Paginate<GetListHomeworkFileResponse>> GetListAsync();
        Task<CreatedHomeworkFileResponse> AddAsync(CreateHomeworkFileRequest createHomeworkRequest);
        Task<DeletedHomeworkFileResponse> DeleteAsync(Guid homeworkId);
        Task<Paginate<GetListFileResponse>> GetListByHomeworkIdAsync(Guid userId);




    }
}
