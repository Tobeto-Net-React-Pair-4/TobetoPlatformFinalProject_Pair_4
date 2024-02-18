using AutoMapper;
using Business.Abstracts;
using Business.Dtos.ContentLikedByUser.Requests;
using Business.Dtos.ContentLikedByUser.Response;
using Business.Dtos.User.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class ContentLikedByUserManager : IContentLikedByUserService
    {
        private IContentLikedByUserDal _contentLikedByUserDal;
        private IMapper _mapper;
        private ContentLikedByUserBusinessRules _clbuBusinessRules;
        public ContentLikedByUserManager(IContentLikedByUserDal contentLikedByUserDal, IMapper mapper, ContentLikedByUserBusinessRules clbuBusinessRules)
        {
            _contentLikedByUserDal = contentLikedByUserDal;
            _mapper = mapper;
            _clbuBusinessRules = clbuBusinessRules;
        }
        public async Task<CreatedContentLikedByUserResponse> AddAsync(CreateContentLikedByUserRequest createContentLikedByUserRequest)
        {
            await _clbuBusinessRules.CheckIfContentExists(createContentLikedByUserRequest.ContentId);
            await _clbuBusinessRules.CheckIfUserExists(createContentLikedByUserRequest.UserId);

            ContentLikedByUser contentLikedByUser = _mapper.Map<ContentLikedByUser>(createContentLikedByUserRequest);
            contentLikedByUser.Id = Guid.NewGuid();

            ContentLikedByUser createdContentLikedByUser = await _contentLikedByUserDal.AddAsync(contentLikedByUser);
            return _mapper.Map<CreatedContentLikedByUserResponse>(createdContentLikedByUser);
        }

        public async Task<DeletedContentLikedByUserResponse> DeleteAsync(DeleteContentLikedByUserRequest deleteContentLikedByUserRequest)
        {
            ContentLikedByUser contentLikedByUser = await _clbuBusinessRules.CheckIfContentLikedByUserExists
                (deleteContentLikedByUserRequest.UserId, deleteContentLikedByUserRequest.ContentId);

            await _contentLikedByUserDal.DeleteAsync(contentLikedByUser);
            return _mapper.Map<DeletedContentLikedByUserResponse>(contentLikedByUser);
        }

        public async Task<Paginate<GetListContentLikedByUserResponse>> GetListAsync()
        {
            var data = await _contentLikedByUserDal.GetListAsync();
            return _mapper.Map<Paginate<GetListContentLikedByUserResponse>>(data);
        }

        public async Task<Paginate<GetListUserResponse>> GetListByContentIdAsync(Guid contentId)
        {
            await _clbuBusinessRules.CheckIfContentExists(contentId);

            var data = await _contentLikedByUserDal.GetListAsync(clbu => clbu.ContentId == contentId);
            return _mapper.Map<Paginate<GetListUserResponse>>(data);
        }
    }
}
