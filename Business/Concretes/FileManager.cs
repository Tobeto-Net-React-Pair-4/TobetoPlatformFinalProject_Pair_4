using AutoMapper;
using Business.Abstracts;
using Business.Dtos.File.Requests;
using Business.Dtos.File.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using File = Entities.Concretes.File;

namespace Business.Concretes
{
    public class FileManager : IFileService
    {
        private IFileDal _fileDal;
        private IMapper _mapper;
        public FileManager(IFileDal fileDal, IMapper mapper)
        {
            _fileDal = fileDal;
            _mapper = mapper;
        }
        public async Task<CreatedFileResponse> AddAsync(CreateFileRequest createFileRequest)
        {

            File file = _mapper.Map<File>(createFileRequest);
            file.Id = Guid.NewGuid();

            File createdFile = await _fileDal.AddAsync(file);
            return _mapper.Map<CreatedFileResponse>(createdFile);
        }

        public async Task<DeletedFileResponse> DeleteAsync(Guid Id)
        {

            File file = await _fileDal.GetAsync(p => p.Id == Id);
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
            File file = await _fileDal.GetAsync(p => p.Id == updateFileRequest.Id);
            _mapper.Map(updateFileRequest, file);
            await _fileDal.UpdateAsync(file);
            return _mapper.Map<UpdatedFileResponse>(file);
        }
        public async Task<GetFileResponse> GetByIdAsync(Guid Id)
        {
            File file = await _fileDal.GetAsync(p => p.Id == Id);

            return _mapper.Map<GetFileResponse>(file);
        }
    }
}
