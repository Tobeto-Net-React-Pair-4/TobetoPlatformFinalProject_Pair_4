using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Course.Responses;
using Business.Dtos.File.Responses;
using Business.Dtos.Homework.Requests;
using Business.Dtos.Homework.Responses;
using Business.Dtos.HomeworkFile.Requests;
using Business.Dtos.HomeworkFile.Responses;
using Business.Dtos.UserCourse.Requests;
using Business.Dtos.UserCourse.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class HomeworkFileManager : IHomeworkFileService

    {
        IHomeworkFileDal _homeworkFileDal;
        IMapper _mapper;
        HomeworkFileBusinessRules _homeworkFileBusinessRules;
        public HomeworkFileManager(IHomeworkFileDal homeworkFileDal, IMapper mapper, HomeworkFileBusinessRules homeworkFileBusinessRules)
        {
            _homeworkFileDal = homeworkFileDal;
            _mapper = mapper;
            _homeworkFileBusinessRules = homeworkFileBusinessRules;
        }
        public async Task<CreatedHomeworkFileResponse> AddAsync(CreateHomeworkFileRequest createHomeworkFileRequest)
        {
            await _homeworkFileBusinessRules.CheckIfHomeworkExists(createHomeworkFileRequest.HomeworkId);
            await _homeworkFileBusinessRules.CheckIfFileExists(createHomeworkFileRequest.FileId);

            HomeworkFile homeworkFile = _mapper.Map<HomeworkFile>(createHomeworkFileRequest);
            var createdHomeworkFile = await _homeworkFileDal.AddAsync(homeworkFile);
            CreatedHomeworkFileResponse createdHomeworkFileResponse = _mapper.Map<CreatedHomeworkFileResponse>(createdHomeworkFile);
            return createdHomeworkFileResponse;
        }

        public async Task<DeletedHomeworkFileResponse> DeleteAsync(DeleteHomeworkFileRequest deleteHomeworkFileRequest)
        {
            HomeworkFile homeworkFile = await _homeworkFileBusinessRules.CheckIfHomeworkFileExists
                (deleteHomeworkFileRequest.HomeworkId, deleteHomeworkFileRequest.FileId);
 
            await _homeworkFileDal.DeleteAsync(homeworkFile);
            return _mapper.Map<DeletedHomeworkFileResponse>(homeworkFile);
        }

        public async Task<Paginate<GetListHomeworkFileResponse>> GetListAsync()
        {
            var data = await _homeworkFileDal.GetListAsync(include: uc => uc.Include(uc => uc.Homework).Include(uc => uc.File));
            return _mapper.Map<Paginate<GetListHomeworkFileResponse>>(data);
        }

        public async Task<Paginate<GetListFileResponse>> GetListByHomeworkIdAsync(Guid homeworkId)
        {
            await _homeworkFileBusinessRules.CheckIfHomeworkExists(homeworkId);

            var data = await _homeworkFileDal.GetListAsync(uc => uc.HomeworkId == homeworkId,
                include: uc => uc.Include(uc => uc.File));
            return _mapper.Map<Paginate<GetListFileResponse>>(data);
        }

    }
}
