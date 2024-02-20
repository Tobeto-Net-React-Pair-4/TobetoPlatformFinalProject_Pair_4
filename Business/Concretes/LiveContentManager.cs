using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.CourseLiveContent.Requests;
using Business.Dtos.CourseLiveContent.Responses;
using Business.Dtos.Liked.Requests;
using Business.Dtos.Liked.Responses;
using Business.Dtos.LiveContent.Requests;
using Business.Dtos.LiveContent.Responses;
using Business.Dtos.PersonalInfo.Requests;
using Business.Dtos.PersonalInfo.Responses;
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
    public class LiveContentManager : ILiveContentService
    {
        IMapper _mapper;
        ILiveContentDal _liveContentDal;
        ICourseLiveContentService _courseLiveContentService;
        ILikeService _likeService;

        public LiveContentManager(IMapper mapper, ILiveContentDal liveContentDal, ICourseLiveContentService courseLiveContentService, ILikeService likeService)
        {
            _mapper = mapper;
            _liveContentDal = liveContentDal;
            _courseLiveContentService = courseLiveContentService;
            _likeService = likeService;
        }

        [SecuredOperation("admin")]
        public async Task<CreatedLiveContentResponse> AddAsync(CreateLiveContentRequest createLiveContentRequest)
        {
            LiveContent liveContent = _mapper.Map<LiveContent>(createLiveContentRequest);
            liveContent.LikeId = (await _likeService.AddAsync(new CreateLikeRequest())).Id;
            var createdLiveContent = await _liveContentDal.AddAsync(liveContent);
            CreatedLiveContentResponse result = _mapper.Map<CreatedLiveContentResponse>(createdLiveContent);
            return result;
        }

        public async Task<CreatedCourseLiveContentResponse> AssignContentAsync(CreateCourseLiveContentRequest createCourseLiveContentRequest)
        {
            return await _courseLiveContentService.AddAsync(createCourseLiveContentRequest);
        }

        [SecuredOperation("admin")]
        public async Task<DeletedLiveContentResponse> DeleteAsync(Guid liveContentId)
        {           
            LiveContent liveContent = await _liveContentDal.GetAsync(p => p.Id == liveContentId);
            await _liveContentDal.DeleteAsync(liveContent);
            return _mapper.Map<DeletedLiveContentResponse>(liveContent);
        }

        public async Task<GetLiveContentResponse> GetByIdAsync(Guid liveContentId)
        {
            var result = await _liveContentDal.GetAsync(l => l.Id == liveContentId);
            return _mapper.Map<GetLiveContentResponse>(result);
        }

        public async Task<Paginate<GetListLiveContentResponse>> GetListAsync()
        {
            var result = await _liveContentDal.GetListAsync();
            return _mapper.Map<Paginate<GetListLiveContentResponse>>(result);
        }

        public async Task<Paginate<GetListLiveContentResponse>> GetListByCourseIdAsync(Guid courseId)
        {
            return await _courseLiveContentService.GetListByCourseIdAsync(courseId);
        }

        [SecuredOperation("admin")]
        public async Task<UpdatedLiveContentResponse> UpdateAsync(UpdateLiveContentRequest updateLiveContentRequest)
        {
            LiveContent liveContent = await _liveContentDal.GetAsync(p => p.Id == updateLiveContentRequest.Id);
            _mapper.Map(updateLiveContentRequest, liveContent);
            liveContent = await _liveContentDal.UpdateAsync(liveContent);
            return _mapper.Map<UpdatedLiveContentResponse>(liveContent);
        }
    }
}
