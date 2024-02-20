using Business.Abstracts;
using Business.Dtos.File.Responses;
using Business.Dtos.Homework.Responses;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Messages;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class HomeworkFileBusinessRules : BaseBusinessRules<HomeworkFile>
    {
        IHomeworkFileDal _homeworkFileDal;
        IFileService _fileService;
        IHomeworkService _homeworkService;
        public HomeworkFileBusinessRules(IHomeworkService homeworkService, IHomeworkFileDal homeworkFileDal, IFileService fileService) : base(homeworkFileDal) 
        {

            _homeworkService = homeworkService;
            _fileService = fileService;
            _homeworkFileDal = homeworkFileDal;
        }
        public async Task<HomeworkFile> CheckIfHomeworkFileExists(Guid homeworkId, Guid fileId)
        {
            HomeworkFile homeworkFile = await _homeworkFileDal.GetAsync
                (hf => hf.HomeworkId == homeworkId && hf.FileId == fileId);
            if (homeworkFile == null)
            {
                throw new BusinessException(BusinessCoreMessages.EntityNotFound);
            }
            return homeworkFile;
        }
        public async Task CheckIfHomeworkExists(Guid homeworkId)
        {
            GetHomeworkResponse homework = await _homeworkService.GetByIdAsync(homeworkId);
            if (homework == null)
            {
                throw new BusinessException(BusinessCoreMessages.EntityNotFound);
            }
        }
        public async Task CheckIfFileExists(Guid fileId)
        {
            GetFileResponse file = await _fileService.GetByIdAsync(fileId);
            if (file == null)
            {
                throw new BusinessException(BusinessCoreMessages.EntityNotFound);
            }
        }
    }
}
