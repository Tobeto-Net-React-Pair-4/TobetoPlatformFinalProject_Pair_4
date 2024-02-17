using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Favourite.Requests;
using Business.Dtos.Favourite.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class FavouriteManager : IFavouriteService
    {
        private IMapper _mapper;
        IFavouriteDal _favouriteDal;

        public FavouriteManager(IMapper mapper, IFavouriteDal favouriteDal)
        {
            _mapper = mapper;
            _favouriteDal = favouriteDal;
        }
        public async Task<CreatedFavouriteResponse> AddAsync(CreateFavouriteRequest createFavouriteRequest)
        {
            Favourite favourite = _mapper.Map<Favourite>(createFavouriteRequest);
            favourite.Id = Guid.NewGuid();
            Favourite createdFavourite = await _favouriteDal.AddAsync(favourite);

            return _mapper.Map<CreatedFavouriteResponse>(createdFavourite);
        }

        public async Task<DeletedFavouriteResponse> DeleteAsync(Guid Id)
        {
            Favourite favourite = await _favouriteDal.GetAsync(p => p.Id == Id);
            await _favouriteDal.DeleteAsync(favourite);
            return _mapper.Map<DeletedFavouriteResponse>(favourite);
        }

        public async Task<GetFavouriteResponse> GetByIdAsync(Guid Id)
        {
            var result = await _favouriteDal.GetAsync(p => p.Id == Id);
            return _mapper.Map<GetFavouriteResponse>(result);
        }

        public async Task<Paginate<GetListFavouriteResponse>> GetListAsync()
        {
            var data = await _favouriteDal.GetListAsync();
            return _mapper.Map<Paginate<GetListFavouriteResponse>>(data);
        }

        public async Task<UpdatedFavouriteResponse> UpdateAsync(UpdateFavouriteRequest updateFavouriteRequest)
        {
            Favourite favourite = await _favouriteDal.GetAsync(p => p.Id == updateFavouriteRequest.Id);
            _mapper.Map(updateFavouriteRequest, favourite);
            favourite = await _favouriteDal.UpdateAsync(favourite);
            return _mapper.Map<UpdatedFavouriteResponse>(favourite);
        }

    }
}
