using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
using Business.Dtos.UserCourse.Requests;
using Business.Dtos.UserCourse.Responses;
using Business.Rules;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class CourseManager : ICourseService
    {
        private CourseBusinessRules _courseBusinessRules;
        private ICourseDal _courseDal;
        private IMapper _mapper;
        private IUserCourseService _userCourseService;
        public CourseManager(ICourseDal courseDal, IMapper mapper, CourseBusinessRules courseBusinessRules, IUserCourseService userCourseService)
        {
            _courseDal = courseDal;
            _mapper = mapper;
            _courseBusinessRules = courseBusinessRules;
            _userCourseService = userCourseService;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CourseValidator))]
        [CacheRemoveAspect("ICourseService.Get")]
        public async Task<CreatedCourseResponse> AddAsync(CreateCourseRequest createCourseRequest)
        {
            await _courseBusinessRules.CheckIfCategoryExists(createCourseRequest.CategoryId);
            await _courseBusinessRules.CheckIfInstructorExists(createCourseRequest.InstructorId);
            await _courseBusinessRules.EachCategoryMustContainMax20Course(createCourseRequest.CategoryId);
            await _courseBusinessRules.CheckUniqueCourseName(createCourseRequest.Name);

            Course course = _mapper.Map<Course>(createCourseRequest);
            course.Id = Guid.NewGuid();

            Course createdCourse = await _courseDal.AddAsync(course);

            return _mapper.Map<CreatedCourseResponse>(createdCourse);
        }

        [CacheAspect]
        public async Task<Paginate<GetListCourseResponse>> GetListAsync()
        {
            var data = await _courseDal.GetListAsync(
                include: p => p.Include(p => p.Category).Include(b => b.Instructor));

            return _mapper.Map<Paginate<GetListCourseResponse>>(data);
        }

        [SecuredOperation("admin")]
        public async Task<DeletedCourseResponse> DeleteAsync(Guid courseId)
        {
            await _courseBusinessRules.CheckIfExistsById(courseId);

            Course course = await _courseDal.GetAsync(p => p.Id == courseId);
            await _courseDal.DeleteAsync(course);
            return _mapper.Map<DeletedCourseResponse>(course);
        }

        [ValidationAspect(typeof(CourseValidator))]
        [CacheRemoveAspect("ICourseService.Get")]
        [SecuredOperation("admin")]
        public async Task<UpdatedCourseResponse> UpdateAsync(UpdateCourseRequest updateCourseRequest)
        {
            await _courseBusinessRules.CheckIfExistsById(updateCourseRequest.Id);
            await _courseBusinessRules.CheckIfCategoryExists(updateCourseRequest.CategoryId);
            await _courseBusinessRules.CheckIfInstructorExists(updateCourseRequest.InstructorId);

            Course course = await _courseDal.GetAsync(p => p.Id == updateCourseRequest.Id);
            _mapper.Map(updateCourseRequest, course);
            course = await _courseDal.UpdateAsync(course);
            return _mapper.Map<UpdatedCourseResponse>(course);
        }

        public async Task<GetByIdCourseResponse> GetByIdAsync(Guid courseId)
        {
            await _courseBusinessRules.CheckIfExistsById(courseId);

            Course course = await _courseDal.GetAsync(p => p.Id == courseId,
                include: i => i.Include(i => i.Instructor).Include(ca => ca.Category).Include(u => u.UserCourses));
            return _mapper.Map<GetByIdCourseResponse>(course);
        }

        public async Task<Paginate<GetListCourseResponse>> GetListByUserIdAsync(Guid userId)
        {
            return await _userCourseService.GetListByUserIdAsync(userId);
        }

        public async Task<CreatedUserCourseResponse> AssignCourseToUserAsync(CreateUserCourseRequest createUserCourseRequest)
        {
            return await _userCourseService.AddAsync(createUserCourseRequest);
        }

    }
}
