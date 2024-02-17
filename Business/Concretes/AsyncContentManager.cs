using AutoMapper;
using Business.Abstracts;
using Business.Dtos.AsyncContent.Requests;
using Business.Dtos.AsyncContent.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class AsyncContentManager : IAsyncContentService
    {
        private IAsyncContentDal _asyncContentDal;
        private IMapper _mapper;
        public AsyncContentManager(IAsyncContentDal asyncContentDal, IMapper mapper)
        {
            _asyncContentDal = asyncContentDal;
            _mapper = mapper;
        }
        public async Task<CreatedAsyncContentResponse> AddAsync(CreateAsyncContentRequest createAsyncContentRequest)
        {

            AsyncContent asyncContent = _mapper.Map<AsyncContent>(createAsyncContentRequest);
            asyncContent.Id = Guid.NewGuid();

            AsyncContent createdAsyncContent = await _asyncContentDal.AddAsync(asyncContent);
            return _mapper.Map<CreatedAsyncContentResponse>(createdAsyncContent);
        }

        public async Task<DeletedAsyncContentResponse> DeleteAsync(Guid Id)
        {

            AsyncContent asyncContent = await _asyncContentDal.GetAsync(p => p.Id == Id);
            await _asyncContentDal.DeleteAsync(asyncContent);
            return _mapper.Map<DeletedAsyncContentResponse>(asyncContent);
        }

        public async Task<Paginate<GetListAsyncContentResponse>> GetListAsync()
        {
            var data = await _asyncContentDal.GetListAsync();
            return _mapper.Map<Paginate<GetListAsyncContentResponse>>(data);
        }

        public async Task<UpdatedAsyncContentResponse> UpdateAsync(UpdateAsyncContentRequest updateAsyncContentRequest)
        {
            AsyncContent asyncContent = await _asyncContentDal.GetAsync(p => p.Id == updateAsyncContentRequest.Id);
            _mapper.Map(updateAsyncContentRequest, asyncContent);
            await _asyncContentDal.UpdateAsync(asyncContent);
            return _mapper.Map<UpdatedAsyncContentResponse>(asyncContent);
        }
        public async Task<GetAsyncContentResponse> GetByIdAsync(Guid Id)
        {
            AsyncContent asyncContent = await _asyncContentDal.GetAsync(p => p.Id == Id);

            return _mapper.Map<GetAsyncContentResponse>(asyncContent);
        }
    }
}
