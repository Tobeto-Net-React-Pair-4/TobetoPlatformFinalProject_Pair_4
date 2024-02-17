using AutoMapper;
using Business.Abstracts;
using Business.Dtos.CourseAsyncContent.Requests;
using Business.Dtos.CourseAsyncContent.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class CourseAsyncContentManager : ICourseAsyncContentService
    {
        private ICourseAsyncContentDal _courseAsyncContentDal;
        private IMapper _mapper;
        public CourseAsyncContentManager(ICourseAsyncContentDal courseAsyncContentDal, IMapper mapper)
        {
            _courseAsyncContentDal = courseAsyncContentDal;
            _mapper = mapper;
        }
        public async Task<CreatedCourseAsyncContentResponse> AddAsync(CreateCourseAsyncContentRequest createCourseAsyncContentRequest)
        {

            CourseAsyncContent courseAsyncContent = _mapper.Map<CourseAsyncContent>(createCourseAsyncContentRequest);
            courseAsyncContent.Id = Guid.NewGuid();

            CourseAsyncContent createdCourseAsyncContent = await _courseAsyncContentDal.AddAsync(courseAsyncContent);
            return _mapper.Map<CreatedCourseAsyncContentResponse>(createdCourseAsyncContent);
        }

        public async Task<DeletedCourseAsyncContentResponse> DeleteAsync(Guid Id)
        {

            CourseAsyncContent courseAsyncContent = await _courseAsyncContentDal.GetAsync(p => p.Id == Id);
            await _courseAsyncContentDal.DeleteAsync(courseAsyncContent);
            return _mapper.Map<DeletedCourseAsyncContentResponse>(courseAsyncContent);
        }


        public async Task<Paginate<GetListCourseAsyncContentResponse>> GetListAsync()
        {
            var data = await _courseAsyncContentDal.GetListAsync();
            return _mapper.Map<Paginate<GetListCourseAsyncContentResponse>>(data);
        }

        public async Task<UpdatedCourseAsyncContentResponse> UpdateAsync(UpdateCourseAsyncContentRequest updateCourseAsyncContentRequest)
        {
            CourseAsyncContent courseAsyncContent = await _courseAsyncContentDal.GetAsync(p => p.Id == updateCourseAsyncContentRequest.Id);
            _mapper.Map(updateCourseAsyncContentRequest, courseAsyncContent);
            await _courseAsyncContentDal.UpdateAsync(courseAsyncContent);
            return _mapper.Map<UpdatedCourseAsyncContentResponse>(courseAsyncContent);
        }
        public async Task<GetCourseAsyncContentResponse> GetByIdAsync(Guid Id)
        {
            CourseAsyncContent courseAsyncContent = await _courseAsyncContentDal.GetAsync(p => p.Id == Id);

            return _mapper.Map<GetCourseAsyncContentResponse>(courseAsyncContent);
        }
    }
}
