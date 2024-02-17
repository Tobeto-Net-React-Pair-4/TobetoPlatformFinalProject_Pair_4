using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Course.Responses;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.UserCourse.Requests;
using Business.Dtos.UserCourse.Responses;
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
        public UserCourseManager(IUserCourseDal userCourseDal, IMapper mapper)
        {
            _userCourseDal = userCourseDal;
            _mapper = mapper;
        }
        public async Task<Paginate<GetListUserCourseResponse>> GetListAsync()
        {
            var data = await _userCourseDal.GetListAsync(include: uc => uc.Include(uc => uc.User).Include(uc => uc.Course));

            return _mapper.Map<Paginate<GetListUserCourseResponse>>(data);
        }
        public async Task<CreatedUserCourseResponse> AddAsync(CreateUserCourseRequest createUserCourseRequest)
        {
            UserCourse userCourse = _mapper.Map<UserCourse>(createUserCourseRequest);
            var createdUserCourse = await _userCourseDal.AddAsync(userCourse);
            CreatedUserCourseResponse createdUserCourseResponse = _mapper.Map<CreatedUserCourseResponse>(createdUserCourse);
            return createdUserCourseResponse;
        }

        public async Task<Paginate<GetListCourseResponse>> GetListByUserIdAsync(Guid userId)
        {
            var data = await _userCourseDal.GetListAsync(uc => uc.UserId == userId, 
                include: uc => uc.Include(uc => uc.Course).Include(uc => uc.Course.Category).Include(uc => uc.Course.Like));
            return _mapper.Map<Paginate<GetListCourseResponse>>(data);
        }
    }
}
