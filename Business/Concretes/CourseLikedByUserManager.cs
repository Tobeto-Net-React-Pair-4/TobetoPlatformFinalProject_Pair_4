using AutoMapper;
using Business.Abstracts;
using Business.Dtos.CourseLikedByUser.Requests;
using Business.Dtos.CourseLikedByUser.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class CourseLikedByUserManager : ICourseLikedByUserService
    {
        private ICourseLikedByUserDal _courseLikedByUserDal;
        private IMapper _mapper;
        public CourseLikedByUserManager(ICourseLikedByUserDal courseLikedByUserDal, IMapper mapper)
        {
            _courseLikedByUserDal = courseLikedByUserDal;
            _mapper = mapper;
        }
        public async Task<CreatedCourseLikedByUserResponse> AddAsync(CreateCourseLikedByUserRequest createCourseLikedByUserRequest)
        {

            CourseLikedByUser courseLikedByUser = _mapper.Map<CourseLikedByUser>(createCourseLikedByUserRequest);
            courseLikedByUser.Id = Guid.NewGuid();

            CourseLikedByUser createdCourseLikedByUser = await _courseLikedByUserDal.AddAsync(courseLikedByUser);
            return _mapper.Map<CreatedCourseLikedByUserResponse>(createdCourseLikedByUser);
        }

        public async Task<DeletedCourseLikedByUserResponse> DeleteAsync(Guid Id)
        {

            CourseLikedByUser courseLikedByUser = await _courseLikedByUserDal.GetAsync(p => p.Id == Id);
            await _courseLikedByUserDal.DeleteAsync(courseLikedByUser);
            return _mapper.Map<DeletedCourseLikedByUserResponse>(courseLikedByUser);
        }


        public async Task<Paginate<GetListCourseLikedByUserResponse>> GetListAsync()
        {
            var data = await _courseLikedByUserDal.GetListAsync();
            return _mapper.Map<Paginate<GetListCourseLikedByUserResponse>>(data);
        }

        public async Task<UpdatedCourseLikedByUserResponse> UpdateAsync(UpdateCourseLikedByUserRequest updateCourseLikedByUserRequest)
        {
            CourseLikedByUser courseLikedByUser = await _courseLikedByUserDal.GetAsync(p => p.Id == updateCourseLikedByUserRequest.Id);
            _mapper.Map(updateCourseLikedByUserRequest, courseLikedByUser);
            await _courseLikedByUserDal.UpdateAsync(courseLikedByUser);
            return _mapper.Map<UpdatedCourseLikedByUserResponse>(courseLikedByUser);
        }
        public async Task<GetCourseLikedByUserResponse> GetByIdAsync(Guid Id)
        {
            CourseLikedByUser courseLikedByUser = await _courseLikedByUserDal.GetAsync(p => p.Id == Id);

            return _mapper.Map<GetCourseLikedByUserResponse>(courseLikedByUser);
        }
    }
}
