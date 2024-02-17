using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Content.Requests;
using Business.Dtos.Content.Responses;
using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ContentManager : IContentService
    {
        private IMapper _mapper;
        private IContentDal _contentDal;
        private ContentBusinessRules _contentBusinessRules;

        public ContentManager(IMapper mapper, IContentDal contentDal, ContentBusinessRules contentBusinessRules)
        {
            _mapper = mapper;
            _contentDal = contentDal;
            _contentBusinessRules = contentBusinessRules;
        }

        [SecuredOperation("admin")]
        public async Task<CreatedContentResponse> AddAsync(CreateContentRequest createContentRequest)
        {
            await _contentBusinessRules.CheckIfCourseExists(createContentRequest.CourseId);

            Content content = _mapper.Map<Content>(createContentRequest);
            content.Id = Guid.NewGuid();

            Content createdContent = await _contentDal.AddAsync(content);
            return _mapper.Map<CreatedContentResponse>(createdContent);
        }

        [SecuredOperation("admin")]
        public async Task<DeletedContentResponse> DeleteAsync(Guid contentId)
        {
            await _contentBusinessRules.CheckIfExistsById(contentId);

            Content content = await _contentDal.GetAsync(p => p.Id == contentId);
            await _contentDal.DeleteAsync(content);
            return _mapper.Map<DeletedContentResponse>(content);
        }

        public async Task<GetContentResponse> GetByIdAsync(Guid contentId)
        {
            await _contentBusinessRules.CheckIfExistsById(contentId);

            var result = await _contentDal.GetAsync(p => p.Id == contentId);
            return _mapper.Map<GetContentResponse>(result);
        }

        public async Task<Paginate<GetListContentResponse>> GetListAsync()
        {
            var data = await _contentDal.GetListAsync();
            return _mapper.Map<Paginate<GetListContentResponse>>(data);
        }

        [SecuredOperation("admin")]
        public async Task<UpdatedContentResponse> UpdateAsync(UpdateContentRequest updateContentRequest)
        {
            await _contentBusinessRules.CheckIfExistsById(updateContentRequest.Id);
            await _contentBusinessRules.CheckIfCourseExists(updateContentRequest.CourseId);

            Content content = await _contentDal.GetAsync(p => p.Id == updateContentRequest.Id);
            _mapper.Map(updateContentRequest, content);
            content = await _contentDal.UpdateAsync(content);
            return _mapper.Map<UpdatedContentResponse>(content);
        }
    }
}
