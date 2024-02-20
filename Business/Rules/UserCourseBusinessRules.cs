using Business.Abstracts;
using Business.Constants;
using Business.Dtos.Course.Responses;
using Business.Dtos.User.Responses;
using Business.Dtos.UserCourse.Requests;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Messages;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class UserCourseBusinessRules : BaseBusinessRules<UserCourse>
    {
        IUserCourseDal _userCourseDal;
        IUserService _userService;
        public UserCourseBusinessRules
            (IUserCourseDal userCourseDal, IUserService userService) : base(userCourseDal)
        {
            _userCourseDal = userCourseDal;
            _userService = userService;
        }
        public async Task<UserCourse> CheckIfUserCourseExists(Guid courseId, Guid userId)
        {
            UserCourse userCourse = await _userCourseDal.GetAsync
                (uc => uc.CourseId == courseId && uc.UserId == userId);
            if (userCourse == null)
            {
                throw new BusinessException(BusinessCoreMessages.EntityNotFound);
            }
            return userCourse;
        }
        public async Task CheckIfAlreadyAssigned(CreateUserCourseRequest createUserCourseRequest)
        {
            UserCourse userCourse = await _userCourseDal.GetAsync
                (uc => uc.UserId == createUserCourseRequest.UserId && uc.CourseId == createUserCourseRequest.CourseId);
            if (userCourse != null)
            {
                throw new BusinessException("Ders çoktan atanmış");
            }

        }
        public async Task CheckIfUserExists(Guid userId)
        {
            GetByIdUserResponse user = await _userService.GetByIdAsync(userId);
            if (user == null)
            { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
    }
}
