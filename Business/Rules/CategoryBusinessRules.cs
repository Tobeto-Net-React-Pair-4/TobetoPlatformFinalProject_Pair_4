using Business.Constants;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class CategoryBusinessRules : BaseBusinessRules<Category>
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryBusinessRules(ICategoryDal categoryDal) : base(categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task MaximumCountIsTen()
        {
            var result = await _categoryDal.GetListAsync();

            if (result.Count >= 10)
            {
                throw new BusinessException(BusinessMessages.CategoryLimit);
            }
        }
        
        public async Task SameCategoryName(string name)
        {
            var result = await _categoryDal.GetAsync(c => c.Name == name);

            if (result != null)
            {
                throw new BusinessException(BusinessMessages.SameCategoryName);
            }
        }
    }
}
