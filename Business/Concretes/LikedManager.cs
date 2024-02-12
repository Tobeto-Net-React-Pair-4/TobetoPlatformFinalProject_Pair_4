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
    public class LikedManager : ILikedService
    {
        private IMapper _mapper;
        ILikedDal _likedDal;

        public LikedManager(IMapper mapper, ILikedDal likedDal)
        {
            _mapper = mapper;
            _likedDal = likedDal;
        }
        public async Task<CreatedLikedResponse> AddAsync(CreateLikedRequest createLikedRequest)
        {
            Liked liked = _mapper.Map<Liked>(createLikedRequest);
            liked.Id = Guid.NewGuid();

            Liked createdLiked = await _likedDal.AddAsync(liked);

            return _mapper.Map<CreatedLikedResponse>(createdLiked);
        }

        public async Task<DeletedLikedResponse> DeleteAsync(DeleteLikedRequest deleteLikedRequest)
        {
            Liked liked = await _likedDal.GetAsync(p => p.Id == deleteLikedRequest.Id);
            await _likedDal.DeleteAsync(liked);
            return _mapper.Map<DeletedLikedResponse>(liked);
        }

        public async Task<Paginate<GetLikedResponse>> GetByIdAsync(GetLikedRequest getLikedRequest)
        {
            var result = await _likedDal.GetAsync(p => p.Id == getLikedRequest.Id);
            return _mapper.Map<GetLikedResponse>(result);
        }

        public async Task<Paginate<GetListLikedResponse>> GetListAsync()
        {
            var data = await _likedDal.GetListAsync();
            return _mapper.Map<Paginate<GetListLikedResponse>>(data);
        }

        public async Task<UpdatedLikedResponse> UpdateAsync(UpdateLikedRequest updateLikedRequest)
        {
            Liked liked = await _likedDal.GetAsync(p => p.Id == updateLikedRequest.Id);
            _mapper.Map(updateLikedRequest, liked);
            liked = await _likedDal.UpdateAsync(liked);
            return _mapper.Map<UpdatedLikedResponse>(liked);
        }
    }
}
