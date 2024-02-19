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
        public HomeworkFileManager(IHomeworkFileDal homeworkFileDal, IMapper mapper)
        {
            _homeworkFileDal = homeworkFileDal;
            _mapper = mapper;
        }
        public async Task<CreatedHomeworkFileResponse> AddAsync(CreateHomeworkFileRequest createHomeworkFileRequest)
        {
            HomeworkFile homeworkFile = _mapper.Map<HomeworkFile>(createHomeworkFileRequest);
            var createdHomeworkFile = await _homeworkFileDal.AddAsync(homeworkFile);
            CreatedHomeworkFileResponse createdHomeworkFileResponse = _mapper.Map<CreatedHomeworkFileResponse>(createdHomeworkFile);
            return createdHomeworkFileResponse;
        }

        public async Task<DeletedHomeworkFileResponse> DeleteAsync(Guid homeworkId)
        {
            HomeworkFile homeworkFile = await _homeworkFileDal.GetAsync(uc => uc.HomeworkId == homeworkId);
            await _homeworkFileDal.DeleteAsync(homeworkFile);
            return _mapper.Map<DeletedHomeworkFileResponse>(homeworkFile);
        }


        public async Task<Paginate<GetListHomeworkFileResponse>> GetListAsync()
        {
            var data = await _homeworkFileDal.GetListAsync(include: uc => uc.Include(uc => uc.Homework).Include(uc => uc.File));

            return _mapper.Map<Paginate<GetListHomeworkFileResponse>>(data);
        }

        public async Task<Paginate<GetListFileResponse>> GetListByHomeworkIdAsync(Guid userId)
        {
            var data = await _homeworkFileDal.GetListAsync(uc => uc.HomeworkId == userId,
                include: uc => uc.Include(uc => uc.File));
            return _mapper.Map<Paginate<GetListFileResponse>>(data);
        }

    }
}
