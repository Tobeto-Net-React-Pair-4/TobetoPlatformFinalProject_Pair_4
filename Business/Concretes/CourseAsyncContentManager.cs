using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.AsyncContent.Responses;
using Business.Dtos.CourseAsyncContent.Requests;
using Business.Dtos.CourseAsyncContent.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class CourseAsyncContentManager : ICourseAsyncContentService
    {
        private ICourseAsyncContentDal _courseAsyncContentDal;
        private IMapper _mapper;
        private CourseAsyncContentBusinessRules _courseAsyncContentBusinessRules;
        public CourseAsyncContentManager(ICourseAsyncContentDal courseAsyncContentDal, IMapper mapper, CourseAsyncContentBusinessRules courseAsyncContentBusinessRules)
        {
            _courseAsyncContentDal = courseAsyncContentDal;
            _mapper = mapper;
            _courseAsyncContentBusinessRules = courseAsyncContentBusinessRules;
        }

        [SecuredOperation("admin")]
        public async Task<CreatedCourseAsyncContentResponse> AddAsync(CreateCourseAsyncContentRequest createCourseAsyncContentRequest)
        {
            await _courseAsyncContentBusinessRules.CheckIfAsyncContentExists(createCourseAsyncContentRequest.AsyncContentId);
            await _courseAsyncContentBusinessRules.CheckIfCourseExists(createCourseAsyncContentRequest.CourseId);

            CourseAsyncContent courseAsyncContent = _mapper.Map<CourseAsyncContent>(createCourseAsyncContentRequest);
            courseAsyncContent.Id = Guid.NewGuid();

            CourseAsyncContent createdCourseAsyncContent = await _courseAsyncContentDal.AddAsync(courseAsyncContent);
            return _mapper.Map<CreatedCourseAsyncContentResponse>(createdCourseAsyncContent);
        }

        [SecuredOperation("admin")]
        public async Task<DeletedCourseAsyncContentResponse> DeleteAsync(DeleteCourseAsyncContentRequest deleteCourseAsyncContentRequest)
        {
            CourseAsyncContent courseAsyncContent = await _courseAsyncContentBusinessRules.CheckIfCourseAsyncContentExists
                (deleteCourseAsyncContentRequest.CourseId, deleteCourseAsyncContentRequest.AsyncContentId);

            await _courseAsyncContentDal.DeleteAsync(courseAsyncContent);
            return _mapper.Map<DeletedCourseAsyncContentResponse>(courseAsyncContent);
        }

        public async Task<Paginate<GetListCourseAsyncContentResponse>> GetListAsync()
        {
            var data = await _courseAsyncContentDal.GetListAsync();
            return _mapper.Map<Paginate<GetListCourseAsyncContentResponse>>(data);
        }

        public async Task<Paginate<GetListAsyncContentResponse>> GetListByCourseIdAsync(Guid courseId)
        {
            await _courseAsyncContentBusinessRules.CheckIfCourseExists(courseId);

            var data = await _courseAsyncContentDal.GetListAsync(c => c.CourseId == courseId);
            return _mapper.Map<Paginate<GetListAsyncContentResponse>>(data);
        }
    }
}
