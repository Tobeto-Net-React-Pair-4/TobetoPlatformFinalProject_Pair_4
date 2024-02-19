using Business.Abstracts;
using Business.Dtos.Homework.Requests;
using Business.Dtos.Homework.Responses;
using Business.Dtos.HomeworkFile.Requests;
using Business.Dtos.HomeworkFile.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class HomeworkFileManager : IHomeworkFileService

    {
        public Task<CreatedHomeworkFileResponse> AddAsync(CreateHomeworkFileRequest createHomeworkRequest)
        {
            throw new NotImplementedException();
        }

        public Task<DeletedHomeworkResponse> DeleteAsync(Guid homeworkId)
        {
            throw new NotImplementedException();
        }


        public Task<Paginate<GetListHomeworkResponse>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Paginate<GetListHomeworkResponse>> GetListByHomeworkIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
