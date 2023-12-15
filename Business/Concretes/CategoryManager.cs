using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Core.DataAccess.Paging;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        private IMapper _mapper;
        //private CategoryBusinessRules _categoryBusinessRules;
        public CategoryManager(ICategoryDal categoryDal, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
            //_categoryBusinessRules = categoryBusinessRules;
        }
        public async Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest)
        {
            //await _categoryBusinessRules.MaximumCountIsTen();

            Category category = _mapper.Map<Category>(createCategoryRequest);
            category.Id = Guid.NewGuid();

            Category createdCategory = await _categoryDal.AddAsync(category);

            CreatedCategoryResponse createdCategoryResponse = _mapper.Map<CreatedCategoryResponse>(createdCategory);
            return createdCategoryResponse;
        }
        public async Task<Paginate<GetListedCategoryResponse>> GetListAsync()
        {
            var data = await _categoryDal.GetListAsync();

            return _mapper.Map<Paginate<GetListedCategoryResponse>>(data);
        }
        public async Task<DeletedCategoryResponse> Delete(DeleteCategoryRequest deleteCategoryRequest)
        {
            Category category = await _categoryDal.GetAsync(p => p.Id == deleteCategoryRequest.CategoryId);
            await _categoryDal.DeleteAsync(category);
            return _mapper.Map<DeletedCategoryResponse>(category);
        }

        public async Task<UpdatedCategoryResponse> Update(UpdateCategoryRequest updateCategoryRequest)
        {
            Category category = await _categoryDal.GetAsync(p => p.Id == updateCategoryRequest.CategoryId);
            _mapper.Map(updateCategoryRequest, category);
            category = await _categoryDal.UpdateAsync(category);
            return _mapper.Map<UpdatedCategoryResponse>(category);
        }
    }
}
