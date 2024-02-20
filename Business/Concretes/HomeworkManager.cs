using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Homework.Requests;
using Business.Dtos.Homework.Responses;
using Business.Dtos.HomeworkFile.Requests;
using Business.Dtos.HomeworkFile.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class HomeworkManager : IHomeworkService
    {
        IMapper _mapper;
        IHomeworkDal _homeworkDal;
        IHomeworkFileService _homeworkFileService;
        HomeworkBusinessRules _homeworkBusinessRules;
        public HomeworkManager
            (IMapper mapper, IHomeworkDal homeworkDal, HomeworkBusinessRules homeworkBusinessRules, IHomeworkFileService homeworkFileService)
        {
            _mapper = mapper;
            _homeworkDal = homeworkDal;
            _homeworkBusinessRules = homeworkBusinessRules;
            _homeworkFileService = homeworkFileService;
        }

        [SecuredOperation("admin")]
        public async Task<CreatedHomeworkResponse> AddAsync(CreateHomeworkRequest createHomeworkRequest)
        {
            await _homeworkBusinessRules.CheckIfCourseExists(createHomeworkRequest.CourseId);

            Homework homework = _mapper.Map<Homework>(createHomeworkRequest);
            var createdHomework = await _homeworkDal.AddAsync(homework);
            CreatedHomeworkResponse result = _mapper.Map<CreatedHomeworkResponse>(homework);
            return result;
        }

        public async Task<CreatedHomeworkFileResponse> AssignFileToHomeworkAsync(CreateHomeworkFileRequest createHomeworkFileRequest)
        {
            return await _homeworkFileService.AddAsync(createHomeworkFileRequest);
        }

        public async Task<DeletedHomeworkResponse> DeleteAsync(Guid homeworkId)
        {
            await _homeworkBusinessRules.CheckIfExistsById(homeworkId);

            throw new NotImplementedException();
        }

        public async Task<GetHomeworkResponse> GetByIdAsync(Guid homeworkId)
        {
            await _homeworkBusinessRules.CheckIfExistsById(homeworkId);

            throw new NotImplementedException();
        }

        public async Task<Paginate<GetListHomeworkResponse>> GetListAsync()
        {
            var result = await _homeworkDal.GetListAsync();
            return _mapper.Map<Paginate<GetListHomeworkResponse>>(result);
        }

        public async Task<Paginate<GetListHomeworkResponse>> GetListByCourseIdAsync(Guid courseId)
        {
            await _homeworkBusinessRules.CheckIfCourseExists(courseId);

            var result = await _homeworkDal.GetListAsync(h => h.CourseId == courseId);
            return _mapper.Map<Paginate<GetListHomeworkResponse>>(result);
        }

        public async Task<UpdatedHomeworkResponse> UpdateAsync(UpdateHomeworkRequest updateHomeworkRequest)
        {
            await _homeworkBusinessRules.CheckIfExistsById(updateHomeworkRequest.Id);
            await _homeworkBusinessRules.CheckIfLiveContentExists(updateHomeworkRequest.LiveContentId);
            await _homeworkBusinessRules.CheckIfCourseExists(updateHomeworkRequest.CourseId);


            throw new NotImplementedException();
        }
    }
}
