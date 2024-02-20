using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Content.Requests;
using Business.Dtos.Content.Responses;
using Business.Dtos.Liked.Requests;
using Business.Dtos.Liked.Responses;
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
    public class LikeManager : ILikeService
    {
        private IMapper _mapper;
        ILikeDal _likeDal;
        LikeBusinessRules _likeBusinessRules;

        public LikeManager(IMapper mapper, ILikeDal likeDal, LikeBusinessRules likeBusinessRules)
        {
            _mapper = mapper;
            _likeDal = likeDal;
            _likeBusinessRules = likeBusinessRules;
        }
        public async Task<CreatedLikeResponse> AddAsync(CreateLikeRequest createLikedRequest)
        {
            Like liked = _mapper.Map<Like>(createLikedRequest);
            liked.Id = Guid.NewGuid();

            Like createdLiked = await _likeDal.AddAsync(liked);

            return _mapper.Map<CreatedLikeResponse>(createdLiked);
        }

        public async Task<DeletedLikeResponse> DeleteAsync(Guid likeId)
        {
            Like like = await _likeBusinessRules.CheckIfExistsById(likeId);

            await _likeDal.DeleteAsync(like);
            return _mapper.Map<DeletedLikeResponse>(like);
        }

        public async Task<GetLikeResponse> GetByIdAsync(Guid likeId)
        {
            var result = await _likeBusinessRules.CheckIfExistsById(likeId);
            return _mapper.Map<GetLikeResponse>(result);
        }

        public async Task<Paginate<GetListLikeResponse>> GetListAsync()
        {
            var data = await _likeDal.GetListAsync();
            return _mapper.Map<Paginate<GetListLikeResponse>>(data);
        }

        public async Task<UpdatedLikeResponse> UpdateAsync(UpdateLikeRequest updateLikedRequest)
        {
            await _likeBusinessRules.CheckIfExistsById(updateLikedRequest.Id);

            Like liked = await _likeDal.GetAsync(p => p.Id == updateLikedRequest.Id);
            _mapper.Map(updateLikedRequest, liked);
            liked = await _likeDal.UpdateAsync(liked);
            return _mapper.Map<UpdatedLikeResponse>(liked);
        }
    }
}
