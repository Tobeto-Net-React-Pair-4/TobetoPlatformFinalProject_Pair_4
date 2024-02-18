using AutoMapper;
using Business.Abstracts;
using Business.Dtos.CourseFavouritedByUser.Requests;
using Business.Dtos.CourseFavouritedByUser.Responses;
using Business.Dtos.User.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class CourseFavouritedByUserManager : ICourseFavouritedByUserService
    {
        private ICourseFavouritedByUserDal _courseFavouritedByUserDal;
        private IMapper _mapper;
        private CourseFavouritedByUserBusinessRules _courseFavouritedByUserBusinessRules;
        public CourseFavouritedByUserManager
            (ICourseFavouritedByUserDal courseFavouritedByUserDal, IMapper mapper, CourseFavouritedByUserBusinessRules courseFavouritedByUserBusinessRules)
        {
            _courseFavouritedByUserDal = courseFavouritedByUserDal;
            _mapper = mapper;
            _courseFavouritedByUserBusinessRules = courseFavouritedByUserBusinessRules;
        }
        public async Task<CreatedCourseFavouritedByUserResponse> AddAsync(CreateCourseFavouritedByUserRequest createCourseFavouritedByUserRequest)
        {
            await _courseFavouritedByUserBusinessRules.CheckIfCourseExists(createCourseFavouritedByUserRequest.CourseId);
            await _courseFavouritedByUserBusinessRules.CheckIfUserExists(createCourseFavouritedByUserRequest.UserId);

            CourseFavouritedByUser courseFavouritedByUser = _mapper.Map<CourseFavouritedByUser>(createCourseFavouritedByUserRequest);
            courseFavouritedByUser.Id = Guid.NewGuid();

            CourseFavouritedByUser createdCourseFavouritedByUser = await _courseFavouritedByUserDal.AddAsync(courseFavouritedByUser);
            return _mapper.Map<CreatedCourseFavouritedByUserResponse>(createdCourseFavouritedByUser);
        }

        public async Task<DeletedCourseFavouritedByUserResponse> DeleteAsync(DeleteCourseFavouritedByUserRequest deleteCourseFavouritedByUserRequest)
        {
            CourseFavouritedByUser courseFavouritedByUser = await _courseFavouritedByUserBusinessRules.CheckIfCourseFavouritedByUserExists
                (deleteCourseFavouritedByUserRequest.CourseId, deleteCourseFavouritedByUserRequest.UserId);

            await _courseFavouritedByUserDal.DeleteAsync(courseFavouritedByUser);
            return _mapper.Map<DeletedCourseFavouritedByUserResponse>(courseFavouritedByUser);
        }

        public async Task<Paginate<GetListCourseFavouritedByUserResponse>> GetListAsync()
        {
            var data = await _courseFavouritedByUserDal.GetListAsync();
            return _mapper.Map<Paginate<GetListCourseFavouritedByUserResponse>>(data);
        }

        public async Task<Paginate<GetListUserResponse>> GetListByCourseIdAsync(Guid courseId)
        {
            await _courseFavouritedByUserBusinessRules.CheckIfCourseExists(courseId);

            var data = await _courseFavouritedByUserDal.GetListAsync(cfbu => cfbu.CourseId == courseId);
            return _mapper.Map<Paginate<GetListUserResponse>>(data);
        }
    }
}
