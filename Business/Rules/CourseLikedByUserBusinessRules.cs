using Business.Abstracts;
using Business.Dtos.Course.Responses;
using Business.Dtos.User.Responses;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Messages;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class CourseLikedByUserBusinessRules : BaseBusinessRules<CourseLikedByUser>
    {
        ICourseLikedByUserDal _courseLikedByUser;
        ICourseService _courseService;
        IUserService _userService;
        public CourseLikedByUserBusinessRules
            (ICourseLikedByUserDal courseLikedByUserDal, ICourseService courseService, IUserService userService) : base(courseLikedByUserDal) 
        {
            _courseLikedByUser = courseLikedByUserDal;
            _courseService = courseService;
            _userService = userService;
        }
        public async Task<CourseLikedByUser> CheckIfCourseLikedByUserExists(Guid courseId, Guid userId)
        {
            CourseLikedByUser courseLikedByUser = await _courseLikedByUser.GetAsync
                (clbu => clbu.CourseId == courseId && clbu.UserId == userId);
            if (courseLikedByUser == null)
            {
                throw new BusinessException(BusinessCoreMessages.EntityNotFound);
            }
            return courseLikedByUser;
        }
        public async Task CheckIfUserExists(Guid userId)
        {
            GetByIdUserResponse user = await _userService.GetByIdAsync(userId);
            if (user == null)
            { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
        public async Task CheckIfCourseExists(Guid courseId)
        {
            GetByIdCourseResponse course = await _courseService.GetByIdAsync(courseId);
            if (course == null)
            { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
    }
}
