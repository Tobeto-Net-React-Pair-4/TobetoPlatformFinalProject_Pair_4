using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.Appeal.Requests;
using Business.Dtos.Appeal.Responses;
using Business.Dtos.SocialMediaAccount.Requests;
using Business.Dtos.SocialMediaAccount.Responses;
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
    public class SocialMediaManager : ISocialMediaService
    {
        private ISocialMediaDal _socialMediaDal;
        private IMapper _mapper;

        public SocialMediaManager(ISocialMediaDal socialMediaDal, IMapper mapper)
        {
            _socialMediaDal = socialMediaDal;
            _mapper = mapper;
        }
        public async Task<CreatedSocialMediaResponse> AddAsync(CreateSocialMediaRequest createSocialMediaRequest)
        {
            SocialMedia socialMediaAccount = _mapper.Map<SocialMedia>(createSocialMediaRequest);
            socialMediaAccount.Id = Guid.NewGuid();

            SocialMedia createdSocialMedia = await _socialMediaDal.AddAsync(socialMediaAccount);
            return _mapper.Map<CreatedSocialMediaResponse>(createdSocialMedia);
        }

        public async Task<DeletedSocialMediaResponse> DeleteAsync(DeleteSocialMediaRequest deleteSocialMediaRequest)
        {
            SocialMedia socialMediaAccount = await _socialMediaDal.GetAsync(p => p.Id == deleteSocialMediaRequest.Id);
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
            SocialMedia socialMediaAccount = await _socialMediaDal.GetAsync(p => p.Id == updateSocialMediaRequest.Id);
            _mapper.Map(updateSocialMediaRequest, socialMediaAccount);
            await _socialMediaDal.UpdateAsync(socialMediaAccount);
            return _mapper.Map<UpdatedSocialMediaResponse>(socialMediaAccount);
        }
    }
}
