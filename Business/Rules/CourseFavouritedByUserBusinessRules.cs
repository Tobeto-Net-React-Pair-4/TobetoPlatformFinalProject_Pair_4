﻿using Business.Abstracts;
using Business.Dtos.AsyncContent.Responses;
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
    public class CourseFavouritedByUserBusinessRules : BaseBusinessRules<CourseFavouritedByUser>
    {
        ICourseFavouritedByUserDal _courseFavouritedByUserDal;
        ICourseService _courseService;
        IUserService _userService;
        public CourseFavouritedByUserBusinessRules
            (ICourseFavouritedByUserDal courseFavouritedByUserDal, IUserService userService, ICourseService courseService) : base(courseFavouritedByUserDal)
        {
            _courseFavouritedByUserDal = courseFavouritedByUserDal;
            _userService = userService;
            _courseService = courseService;
        }
        public async Task<CourseFavouritedByUser> CheckIfCourseFavouritedByUserExists(Guid courseId, Guid userId)
        {
            CourseFavouritedByUser courseFavouritedByUser = await _courseFavouritedByUserDal.GetAsync
                (cfbu => cfbu.CourseId == courseId && cfbu.UserId == userId);
            if (courseFavouritedByUser == null)
            {
                throw new BusinessException(BusinessCoreMessages.EntityNotFound);
            }
            return courseFavouritedByUser;
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
