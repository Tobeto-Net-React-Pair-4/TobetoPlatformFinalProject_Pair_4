using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Course.Responses;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.UserCourse.Requests;
using Business.Dtos.UserCourse.Responses;
using Business.Dtos.UserOperationClaim.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Concretes
{
    public class UserCourseManager : IUserCourseService
    {
        IUserCourseDal _userCourseDal;
        IMapper _mapper;
        UserCourseBusinessRules _userCourseBusinessRules;
        public UserCourseManager(IUserCourseDal userCourseDal, IMapper mapper, UserCourseBusinessRules userCourseBusinessRules)
        {
            _userCourseDal = userCourseDal;
            _mapper = mapper;
            _userCourseBusinessRules = userCourseBusinessRules;
        }
        public async Task<Paginate<GetListUserCourseResponse>> GetListAsync()
        {
            var data = await _userCourseDal.GetListAsync(include: uc => uc.Include(uc => uc.User).Include(uc => uc.Course));
            return _mapper.Map<Paginate<GetListUserCourseResponse>>(data);
        }

        [SecuredOperation("admin")]
        public async Task<CreatedUserCourseResponse> AddAsync(CreateUserCourseRequest createUserCourseRequest)
        {
            await _userCourseBusinessRules.CheckIfAlreadyAssigned(createUserCourseRequest);
            await _userCourseBusinessRules.CheckIfUserExists(createUserCourseRequest.UserId);

            UserCourse userCourse = _mapper.Map<UserCourse>(createUserCourseRequest);
            var createdUserCourse = await _userCourseDal.AddAsync(userCourse);
            CreatedUserCourseResponse createdUserCourseResponse = _mapper.Map<CreatedUserCourseResponse>(createdUserCourse);
            return createdUserCourseResponse;
        }

        public async Task<Paginate<GetListCourseResponse>> GetListByUserIdAsync(Guid userId)
        {
            await _userCourseBusinessRules.CheckIfUserExists(userId);

            var data = await _userCourseDal.GetListAsync(uc => uc.UserId == userId, 
                include: uc => uc.Include(uc => uc.Course).Include(uc => uc.Course.Category).Include(uc => uc.Course.Like));
            return _mapper.Map<Paginate<GetListCourseResponse>>(data);
        }

        [SecuredOperation("admin")]
        public async Task<DeletedUserCourseResponse> DeleteAsync(DeleteUserCourseRequest deleteUserCourseRequest)
        {
            UserCourse userCourse = await _userCourseBusinessRules.CheckIfUserCourseExists
                (deleteUserCourseRequest.CourseId, deleteUserCourseRequest.UserId);
            await _userCourseDal.DeleteAsync(userCourse);
            return _mapper.Map<DeletedUserCourseResponse>(userCourse);
        }
    }
}
