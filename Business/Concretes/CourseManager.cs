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
        public CourseManager(ICourseDal courseDal, IMapper mapper, CourseBusinessRules courseBusinessRules)
        {
            _courseDal = courseDal;
            _mapper = mapper;
            _courseBusinessRules = courseBusinessRules;
        }
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CourseValidator))]
        [CacheRemoveAspect("ICourseService.Get")]
        public async Task<CreatedCourseResponse> AddAsync(CreateCourseRequest createCourseRequest)
        {
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
        public async Task<DeletedCourseResponse> DeleteAsync(DeleteCourseRequest deleteCourseRequest)
        {
            Course course = await _courseDal.GetAsync(p => p.Id == deleteCourseRequest.Id);
            await _courseDal.DeleteAsync(course);
            return _mapper.Map<DeletedCourseResponse>(course);
        }

        [ValidationAspect(typeof(CourseValidator))]
        [CacheRemoveAspect("ICourseService.Get")]

        public async Task<UpdatedCourseResponse> UpdateAsync(UpdateCourseRequest updateCourseRequest)
        {
            Course course = await _courseDal.GetAsync(p => p.Id == updateCourseRequest.Id);
            _mapper.Map(updateCourseRequest, course);
            course = await _courseDal.UpdateAsync(course);
            return _mapper.Map<UpdatedCourseResponse>(course);
        }

        public async Task<GetByIdCourseResponse> GetByIdAsync(GetByIdCourseRequest getByIdCourseRequest)
        {
            Course course = await _courseDal.GetAsync(p => p.Id == getByIdCourseRequest.Id,
                include: i => i.Include(i => i.Instructor).Include(ca => ca.Category).Include(u => u.UserCourses));

            return _mapper.Map<GetByIdCourseResponse>(course);
        }
    }
}
