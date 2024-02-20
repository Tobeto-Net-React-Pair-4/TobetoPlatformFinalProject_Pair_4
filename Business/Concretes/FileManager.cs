using AutoMapper;
using Business.Abstracts;
using Business.Dtos.File.Requests;
using Business.Dtos.File.Responses;
using Business.Dtos.Liked.Requests;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using File = Entities.Concretes.File;

namespace Business.Concretes
{
    public class FileManager : IFileService
    {
        private IFileDal _fileDal;
        private IMapper _mapper;
        private IHomeworkFileService _homeworkFileService;
        private FileBusinessRules _fileBusinessRules;
        public FileManager(IFileDal fileDal, IMapper mapper, FileBusinessRules fileBusinessRules, IHomeworkFileService homeworkFileService)
        {
            _fileDal = fileDal;
            _mapper = mapper;
            _fileBusinessRules = fileBusinessRules;
            _homeworkFileService = homeworkFileService;
        }
        public async Task<CreatedFileResponse> AddAsync(CreateFileRequest createFileRequest)
        {
            await _fileBusinessRules.CheckIfAssignmentExists(createFileRequest.AssignmentId);
            await _fileBusinessRules.CheckIfUserExists(createFileRequest.UserId);

            File file = _mapper.Map<File>(createFileRequest);
            file.Id = Guid.NewGuid();

            File createdFile = await _fileDal.AddAsync(file);
            return _mapper.Map<CreatedFileResponse>(createdFile);
        }

        public async Task<DeletedFileResponse> DeleteAsync(Guid fileId)
        {
            await _fileBusinessRules.CheckIfExistsById(fileId);

            File file = await _fileDal.GetAsync(p => p.Id == fileId);
            await _fileDal.DeleteAsync(file);
            return _mapper.Map<DeletedFileResponse>(file);
        }


        public async Task<Paginate<GetListFileResponse>> GetListAsync()
        {
            var data = await _fileDal.GetListAsync();
            return _mapper.Map<Paginate<GetListFileResponse>>(data);
        }

        public async Task<UpdatedFileResponse> UpdateAsync(UpdateFileRequest updateFileRequest)
        {
            await _fileBusinessRules.CheckIfExistsById(updateFileRequest.Id);
            await _fileBusinessRules.CheckIfAssignmentExists(updateFileRequest.AssignmentId);
            await _fileBusinessRules.CheckIfUserExists(updateFileRequest.UserId);

            File file = await _fileDal.GetAsync(p => p.Id == updateFileRequest.Id);
            _mapper.Map(updateFileRequest, file);
            await _fileDal.UpdateAsync(file);
            return _mapper.Map<UpdatedFileResponse>(file);
        }
        public async Task<GetFileResponse> GetByIdAsync(Guid fileId)
        {
            await _fileBusinessRules.CheckIfExistsById(fileId);

            File file = await _fileDal.GetAsync(p => p.Id == fileId);

            return _mapper.Map<GetFileResponse>(file);
        }

        public async Task<Paginate<GetListFileResponse>> GetListByHomeworkIdAsync(Guid homeworkId)
        {
           return await _homeworkFileService.GetListByHomeworkIdAsync(homeworkId);

        }
    }
}
