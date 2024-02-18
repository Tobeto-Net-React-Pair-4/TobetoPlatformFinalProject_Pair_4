using AutoMapper;
using Business.Abstracts;
using Business.Dtos.CourseLikedByUser.Requests;
using Business.Dtos.CourseLikedByUser.Responses;
using Business.Dtos.User.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class CourseLikedByUserManager : ICourseLikedByUserService
    {
        private ICourseLikedByUserDal _courseLikedByUserDal;
        private IMapper _mapper;
        private CourseLikedByUserBusinessRules _courseLikedByUserBusinessRules;
        public CourseLikedByUserManager
            (ICourseLikedByUserDal courseLikedByUserDal, IMapper mapper, CourseLikedByUserBusinessRules courseLikedByUserBusinessRules)
        {
            _courseLikedByUserDal = courseLikedByUserDal;
            _mapper = mapper;
            _courseLikedByUserBusinessRules = courseLikedByUserBusinessRules;
        }
        public async Task<CreatedCourseLikedByUserResponse> AddAsync(CreateCourseLikedByUserRequest createCourseLikedByUserRequest)
        {
            await _courseLikedByUserBusinessRules.CheckIfCourseExists(createCourseLikedByUserRequest.CourseId);
            await _courseLikedByUserBusinessRules.CheckIfUserExists(createCourseLikedByUserRequest.UserId);

            CourseLikedByUser courseLikedByUser = _mapper.Map<CourseLikedByUser>(createCourseLikedByUserRequest);
            courseLikedByUser.Id = Guid.NewGuid();

            CourseLikedByUser createdCourseLikedByUser = await _courseLikedByUserDal.AddAsync(courseLikedByUser);
            return _mapper.Map<CreatedCourseLikedByUserResponse>(createdCourseLikedByUser);
        }

        public async Task<DeletedCourseLikedByUserResponse> DeleteAsync(DeleteCourseLikedByUserRequests deleteCourseLikedByUserRequests)
        {
            CourseLikedByUser courseLikedByUser = await _courseLikedByUserBusinessRules.CheckIfCourseLikedByUserExists
                (deleteCourseLikedByUserRequests.CourseId, deleteCourseLikedByUserRequests.UserId);

            await _courseLikedByUserDal.DeleteAsync(courseLikedByUser);
            return _mapper.Map<DeletedCourseLikedByUserResponse>(courseLikedByUser);
        }

        public async Task<Paginate<GetListCourseLikedByUserResponse>> GetListAsync()
        {
            var data = await _courseLikedByUserDal.GetListAsync();
            return _mapper.Map<Paginate<GetListCourseLikedByUserResponse>>(data);
        }

        public async Task<Paginate<GetListUserResponse>> GetListByCourseIdAsync(Guid courseId)
        {
            await _courseLikedByUserBusinessRules.CheckIfCourseExists(courseId);

            var data = _courseLikedByUserDal.GetListAsync(clbu => clbu.CourseId == courseId);
            return _mapper.Map<Paginate<GetListUserResponse>>(data);
        }
    }
}
