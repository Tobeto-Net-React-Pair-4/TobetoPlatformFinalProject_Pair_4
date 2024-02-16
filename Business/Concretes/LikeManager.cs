using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Content.Requests;
using Business.Dtos.Content.Responses;
using Business.Dtos.Liked.Requests;
using Business.Dtos.Liked.Responses;
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
        ILikeDal _likedDal;

        public LikeManager(IMapper mapper, ILikeDal likedDal)
        {
            _mapper = mapper;
            _likedDal = likedDal;
        }
        public async Task<CreatedLikeResponse> AddAsync(CreateLikeRequest createLikedRequest)
        {
            Like liked = _mapper.Map<Like>(createLikedRequest);
            liked.Id = Guid.NewGuid();

            Like createdLiked = await _likedDal.AddAsync(liked);

            return _mapper.Map<CreatedLikeResponse>(createdLiked);
        }

        public async Task<DeletedLikeResponse> DeleteAsync(DeleteLikeRequest deleteLikedRequest)
        {
            Like liked = await _likedDal.GetAsync(p => p.Id == deleteLikedRequest.Id);
            await _likedDal.DeleteAsync(liked);
            return _mapper.Map<DeletedLikeResponse>(liked);
        }

        public async Task<GetLikeResponse> GetByIdAsync(GetLikeRequest getLikedRequest)
        {
            var result = await _likedDal.GetAsync(p => p.Id == getLikedRequest.Id);
            return _mapper.Map<GetLikeResponse>(result);
        }

        public async Task<Paginate<GetListLikeResponse>> GetListAsync()
        {
            var data = await _likedDal.GetListAsync();
            return _mapper.Map<Paginate<GetListLikeResponse>>(data);
        }

        public async Task<UpdatedLikeResponse> UpdateAsync(UpdateLikeRequest updateLikedRequest)
        {
            Like liked = await _likedDal.GetAsync(p => p.Id == updateLikedRequest.Id);
            _mapper.Map(updateLikedRequest, liked);
            liked = await _likedDal.UpdateAsync(liked);
            return _mapper.Map<UpdatedLikeResponse>(liked);
        }
    }
}
