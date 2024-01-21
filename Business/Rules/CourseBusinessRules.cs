using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class CourseBusinessRules : BaseBusinessRules
    {
        private readonly ICourseDal _courseDal;
        public CourseBusinessRules(ICourseDal courseDal)
        {
            _courseDal = courseDal;
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
    }
}
