using Business.Abstracts;
using Business.Constants;
using Business.Dtos.Category.Responses;
using Business.Dtos.Instructor.Responses;
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
    public class CourseBusinessRules : BaseBusinessRules<Course>
    {
        private readonly ICourseDal _courseDal;
        private readonly ICategoryService _categoryService;
        private readonly IInstructorService _instructorService;
        public CourseBusinessRules(ICourseDal courseDal, ICategoryService categoryService, IInstructorService instructorService) : base(courseDal)
        {
            _courseDal = courseDal;
            _categoryService = categoryService;
            _instructorService = instructorService;
        }
        public async Task EachCategoryMustContainMax20Course(Guid categoryId)
        {
            var result = await _courseDal.GetListAsync(
                predicate: p => p.CategoryId == categoryId,
                size: 25
                );

            if (result.Count >= 20)
            {
                throw new Exception(BusinessMessages.CategoryCourseLimit);
            }
        }
        public async Task CheckUniqueCourseName(string courseName)
        {
            var result = await _courseDal.GetListAsync(
                predicate: p => p.Name == courseName
                );
            if (result.Items.Count > 0)
            {
                throw new Exception(BusinessMessages.CourseNameAlreadyExists);
            }
        }
        public async Task CheckIfCategoryExists(Guid categoryId)
        {
            GetByIdCategoryResponse category = await _categoryService.GetByIdAsync(categoryId);
            if (category == null)
            {
                throw new BusinessException(BusinessCoreMessages.EntityNotFound);
            }
        }
        public async Task CheckIfInstructorExists(Guid instructorId)
        {
            GetByIdInstructorResponse instructor = await _instructorService.GetByIdAsync(instructorId);
            if (instructor == null)
            {
                throw new BusinessException(BusinessCoreMessages.EntityNotFound);
            }
        }
    }
}
