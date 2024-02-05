using AutoMapper;
using Business.Abstracts;
using Business.Dtos.SocialMediaAccount.Requests;
using Business.Dtos.SocialMediaAccount.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class SocialMediaManager : ISocialMediaService
    {
        private ISocialMediaDal _socialMediaDal;
        private IMapper _mapper;
        private SocialMediaBusinessRules _socialMediaBusinessRules;

        public SocialMediaManager(ISocialMediaDal socialMediaDal, IMapper mapper, SocialMediaBusinessRules socialMediaBusinessRules)
        {
            _socialMediaDal = socialMediaDal;
            _mapper = mapper;
            _socialMediaBusinessRules = socialMediaBusinessRules;
        }
        public async Task<CreatedSocialMediaResponse> AddAsync(CreateSocialMediaRequest createSocialMediaRequest)
        {
            await _socialMediaBusinessRules.MaximumCountIsThree();

            SocialMediaAccount socialMediaAccount = _mapper.Map<SocialMediaAccount>(createSocialMediaRequest);
            socialMediaAccount.Id = Guid.NewGuid();

            SocialMediaAccount createdSocialMedia = await _socialMediaDal.AddAsync(socialMediaAccount);
            return _mapper.Map<CreatedSocialMediaResponse>(createdSocialMedia);
        }

        public async Task<DeletedSocialMediaResponse> DeleteAsync(DeleteSocialMediaRequest deleteSocialMediaRequest)
        {
            SocialMediaAccount socialMediaAccount = await _socialMediaDal.GetAsync(p => p.Id == deleteSocialMediaRequest.Id);
            await _socialMediaDal.DeleteAsync(socialMediaAccount);
            return _mapper.Map<DeletedSocialMediaResponse>(socialMediaAccount);
        }

        public async Task<Paginate<GetListSocialMediaResponse>> GetListAsync()
        {
            var data = await _socialMediaDal.GetListAsync();
            return _mapper.Map<Paginate<GetListSocialMediaResponse>>(data);
        }

        public async Task<UpdatedSocialMediaResponse> UpdateAsync(UpdateSocialMediaRequest updateSocialMediaRequest)
        {
            SocialMediaAccount socialMediaAccount = await _socialMediaDal.GetAsync(p => p.Id == updateSocialMediaRequest.Id);
            _mapper.Map(updateSocialMediaRequest, socialMediaAccount);
            await _socialMediaDal.UpdateAsync(socialMediaAccount);
            return _mapper.Map<UpdatedSocialMediaResponse>(socialMediaAccount);
        }
    }
}
