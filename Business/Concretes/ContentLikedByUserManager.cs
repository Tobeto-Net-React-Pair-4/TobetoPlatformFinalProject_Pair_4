using AutoMapper;
using Business.Abstracts;
using Business.Dtos.ContentLikedByUser.Requests;
using Business.Dtos.ContentLikedByUser.Response;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class ContentLikedByUserManager : IContentLikedByUserService
    {
        private IContentLikedByUserDal _contentLikedByUserDal;
        private IMapper _mapper;
        public ContentLikedByUserManager(IContentLikedByUserDal contentLikedByUserDal, IMapper mapper)
        {
            _contentLikedByUserDal = contentLikedByUserDal;
            _mapper = mapper;
        }
        public async Task<CreatedContentLikedByUserResponse> AddAsync(CreateContentLikedByUserRequest createContentLikedByUserRequest)
        {

            ContentLikedByUser contentLikedByUser = _mapper.Map<ContentLikedByUser>(createContentLikedByUserRequest);
            contentLikedByUser.Id = Guid.NewGuid();

            ContentLikedByUser createdContentLikedByUser = await _contentLikedByUserDal.AddAsync(contentLikedByUser);
            return _mapper.Map<CreatedContentLikedByUserResponse>(createdContentLikedByUser);
        }

        public async Task<DeletedContentLikedByUserResponse> DeleteAsync(Guid Id)
        {

            ContentLikedByUser contentLikedByUser = await _contentLikedByUserDal.GetAsync(p => p.Id == Id);
            await _contentLikedByUserDal.DeleteAsync(contentLikedByUser);
            return _mapper.Map<DeletedContentLikedByUserResponse>(contentLikedByUser);
        }


        public async Task<Paginate<GetListContentLikedByUserResponse>> GetListAsync()
        {
            var data = await _contentLikedByUserDal.GetListAsync();
            return _mapper.Map<Paginate<GetListContentLikedByUserResponse>>(data);
        }

        public async Task<UpdatedContentLikedByUserResponse> UpdateAsync(UpdateContentLikedByUserRequest updateContentLikedByUserRequest)
        {
            ContentLikedByUser contentLikedByUser = await _contentLikedByUserDal.GetAsync(p => p.Id == updateContentLikedByUserRequest.Id);
            _mapper.Map(updateContentLikedByUserRequest, contentLikedByUser);
            await _contentLikedByUserDal.UpdateAsync(contentLikedByUser);
            return _mapper.Map<UpdatedContentLikedByUserResponse>(contentLikedByUser);
        }
        public async Task<GetContentLikedByUserResponse> GetByIdAsync(Guid Id)
        {
            ContentLikedByUser contentLikedByUser = await _contentLikedByUserDal.GetAsync(p => p.Id == Id);

            return _mapper.Map<GetContentLikedByUserResponse>(contentLikedByUser);
        }
    }
}
