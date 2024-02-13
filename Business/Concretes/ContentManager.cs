using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Content.Requests;
using Business.Dtos.Content.Responses;
using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
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
        IContentDal _contentDal;

        public ContentManager(IMapper mapper, IContentDal contentDal)
        {
            _mapper = mapper;
            _contentDal = contentDal;
        }
        public async Task<CreatedContentResponse> AddAsync(CreateContentRequest createContentRequest)
        {
            Content content = _mapper.Map<Content>(createContentRequest);
            content.Id = Guid.NewGuid();

            Content createdContent = await _contentDal.AddAsync(content);

            return _mapper.Map<CreatedContentResponse>(createdContent);
        }

        public async Task<DeletedContentResponse> DeleteAsync(DeleteContentRequest deleteContentRequest)
        {
            Content content = await _contentDal.GetAsync(p => p.Id == deleteContentRequest.Id);
            await _contentDal.DeleteAsync(content);
            return _mapper.Map<DeletedContentResponse>(content);
        }

        public async Task<Paginate<GetContentResponse>> GetByIdAsync(GetContentRequest getContentRequest)
        {
            var result = await _contentDal.GetAsync(p => p.Id == getContentRequest.Id);
            return _mapper.Map<GetContentResponse>(result);
        }

        public async Task<Paginate<GetListContentResponse>> GetListAsync()
        {
            var data = await _contentDal.GetListAsync();
            return _mapper.Map<Paginate<GetListContentResponse>>(data);
        }

        public async Task<UpdatedContentResponse> UpdateAsync(UpdateContentRequest updateContentRequest)
        {
            Content content = await _contentDal.GetAsync(p => p.Id == updateContentRequest.Id);
            _mapper.Map(updateContentRequest, content);
            content = await _contentDal.UpdateAsync(content);
            return _mapper.Map<UpdatedContentResponse>(content);
        }
    }
}
