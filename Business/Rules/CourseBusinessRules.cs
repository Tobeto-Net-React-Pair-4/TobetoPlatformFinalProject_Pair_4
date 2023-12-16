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
        public async Task EachCategoryMustContainMax20Products(Guid categoryId)
        {
            var result = await _courseDal.GetListAsync(
                predicate: p => p.CategoryId == categoryId,
                size: 25
                );

            if (result.Count >= 20)
            {
                throw new Exception("Category course limit has been reached");
            }
        }
    }
}
