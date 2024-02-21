using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.AsyncContent.Requests;
using Business.Dtos.AsyncContent.Responses;
using Business.Dtos.CourseAsyncContent.Requests;
using Business.Dtos.CourseAsyncContent.Responses;
using Business.Dtos.CourseLiveContent.Requests;
using Business.Dtos.CourseLiveContent.Responses;
using Business.Dtos.LiveContent.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class AsyncContentManager : IAsyncContentService
    {
        IAsyncContentDal _asyncContentDal;
        IMapper _mapper;
        AsyncContentBusinessRules _asyncContentBusinessRules;
        ICourseAsyncContentService _courseAsyncContentService;
        public AsyncContentManager(IAsyncContentDal asyncContentDal, IMapper mapper, AsyncContentBusinessRules asyncContentBusinessRules, ICourseAsyncContentService courseAsyncContentService)
        {
            _asyncContentDal = asyncContentDal;
            _mapper = mapper;
            _asyncContentBusinessRules = asyncContentBusinessRules;
            _courseAsyncContentService = courseAsyncContentService;
        }

        [SecuredOperation("admin")]
        public async Task<CreatedAsyncContentResponse> AddAsync(CreateAsyncContentRequest createAsyncContentRequest)
        {
            AsyncContent asyncContent = _mapper.Map<AsyncContent>(createAsyncContentRequest);
            asyncContent.Id = Guid.NewGuid();

            AsyncContent createdAsyncContent = await _asyncContentDal.AddAsync(asyncContent);
            return _mapper.Map<CreatedAsyncContentResponse>(createdAsyncContent);
        }

        [SecuredOperation("admin")]
        public async Task<DeletedAsyncContentResponse> DeleteAsync(Guid asyncContentId)
        {
            await _asyncContentBusinessRules.CheckIfExistsById(asyncContentId);

            AsyncContent asyncContent = await _asyncContentDal.GetAsync(p => p.Id == asyncContentId);
            await _asyncContentDal.DeleteAsync(asyncContent);
            return _mapper.Map<DeletedAsyncContentResponse>(asyncContent);
        }

        [SecuredOperation("admin")]
        public async Task<Paginate<GetListAsyncContentResponse>> GetListAsync()
        {
            var data = await _asyncContentDal.GetListAsync();
            return _mapper.Map<Paginate<GetListAsyncContentResponse>>(data);
        }

        [SecuredOperation("admin")]
        public async Task<UpdatedAsyncContentResponse> UpdateAsync(UpdateAsyncContentRequest updateAsyncContentRequest)
        {
            await _asyncContentBusinessRules.CheckIfExistsById(updateAsyncContentRequest.Id);

            AsyncContent asyncContent = await _asyncContentDal.GetAsync(p => p.Id == updateAsyncContentRequest.Id);
            _mapper.Map(updateAsyncContentRequest, asyncContent);
            await _asyncContentDal.UpdateAsync(asyncContent);
            return _mapper.Map<UpdatedAsyncContentResponse>(asyncContent);
        }
        public async Task<GetAsyncContentResponse> GetByIdAsync(Guid asyncContentId)
        {
            await _asyncContentBusinessRules.CheckIfExistsById(asyncContentId);

            AsyncContent asyncContent = await _asyncContentDal.GetAsync(p => p.Id == asyncContentId);

            return _mapper.Map<GetAsyncContentResponse>(asyncContent);
        }

        public async Task<Paginate<GetListAsyncContentResponse>> GetListAsyncContentByCourseIdAsync(Guid courseId)
        {
            return await _courseAsyncContentService.GetListByCourseIdAsync(courseId);
        }

        [SecuredOperation("admin")]
        public async Task<CreatedCourseAsyncContentResponse> AssignAsyncContentAsync(CreateCourseAsyncContentRequest createCourseAsyncContentRequest)
        {
            return await _courseAsyncContentService.AddAsync(createCourseAsyncContentRequest);
        }

    
    }
}
