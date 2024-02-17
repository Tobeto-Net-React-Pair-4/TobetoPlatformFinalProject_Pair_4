using AutoMapper;
using Business.Abstracts;
using Business.Dtos.CourseFavouritedByUser.Requests;
using Business.Dtos.CourseFavouritedByUser.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class CourseFavouritedByUserManager : ICourseFavouritedByUserService
    {
        private ICourseFavouritedByUserDal _courseFavouritedByUserDal;
        private IMapper _mapper;
        public CourseFavouritedByUserManager(ICourseFavouritedByUserDal courseFavouritedByUserDal, IMapper mapper)
        {
            _courseFavouritedByUserDal = courseFavouritedByUserDal;
            _mapper = mapper;
        }
        public async Task<CreatedCourseFavouritedByUserResponse> AddAsync(CreateCourseFavouritedByUserRequest createCourseFavouritedByUserRequest)
        {

            CourseFavouritedByUser courseFavouritedByUser = _mapper.Map<CourseFavouritedByUser>(createCourseFavouritedByUserRequest);
            courseFavouritedByUser.Id = Guid.NewGuid();

            CourseFavouritedByUser createdCourseFavouritedByUser = await _courseFavouritedByUserDal.AddAsync(courseFavouritedByUser);
            return _mapper.Map<CreatedCourseFavouritedByUserResponse>(createdCourseFavouritedByUser);
        }

        public async Task<DeletedCourseFavouritedByUserResponse> DeleteAsync(Guid Id)
        {

            CourseFavouritedByUser courseFavouritedByUser = await _courseFavouritedByUserDal.GetAsync(p => p.Id == Id);
            await _courseFavouritedByUserDal.DeleteAsync(courseFavouritedByUser);
            return _mapper.Map<DeletedCourseFavouritedByUserResponse>(courseFavouritedByUser);
        }


        public async Task<Paginate<GetListCourseFavouritedByUserResponse>> GetListAsync()
        {
            var data = await _courseFavouritedByUserDal.GetListAsync();
            return _mapper.Map<Paginate<GetListCourseFavouritedByUserResponse>>(data);
        }

        public async Task<UpdatedCourseFavouritedByUserResponse> UpdateAsync(UpdateCourseFavouritedByUserRequest updateCourseFavouritedByUserRequest)
        {
            CourseFavouritedByUser courseFavouritedByUser = await _courseFavouritedByUserDal.GetAsync(p => p.Id == updateCourseFavouritedByUserRequest.Id);
            _mapper.Map(updateCourseFavouritedByUserRequest, courseFavouritedByUser);
            await _courseFavouritedByUserDal.UpdateAsync(courseFavouritedByUser);
            return _mapper.Map<UpdatedCourseFavouritedByUserResponse>(courseFavouritedByUser);
        }
        public async Task<GetCourseFavouritedByUserResponse> GetByIdAsync(Guid Id)
        {
            CourseFavouritedByUser courseFavouritedByUser = await _courseFavouritedByUserDal.GetAsync(p => p.Id == Id);

            return _mapper.Map<GetCourseFavouritedByUserResponse>(courseFavouritedByUser);
        }
    }
}
