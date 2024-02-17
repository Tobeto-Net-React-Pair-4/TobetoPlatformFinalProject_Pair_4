using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Category.Requests;
using Business.Dtos.Category.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        private IMapper _mapper;
        private CategoryBusinessRules _categoryBusinessRules;
        public CategoryManager(ICategoryDal categoryDal, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
        }

        [SecuredOperation("admin")]
        public async Task<CreatedCategoryResponse> AddAsync(CreateCategoryRequest createCategoryRequest)
        {
            await _categoryBusinessRules.MaximumCountIsTen();
            await _categoryBusinessRules.SameCategoryName(createCategoryRequest.Name);

            Category category = _mapper.Map<Category>(createCategoryRequest);
            category.Id = Guid.NewGuid();

            Category createdCategory = await _categoryDal.AddAsync(category);

            CreatedCategoryResponse createdCategoryResponse = _mapper.Map<CreatedCategoryResponse>(createdCategory);
            return createdCategoryResponse;
        }
        public async Task<Paginate<GetListCategoryResponse>> GetListAsync()
        {
            var data = await _categoryDal.GetListAsync();
            return _mapper.Map<Paginate<GetListCategoryResponse>>(data);
        }

        [SecuredOperation("admin")]
        public async Task<DeletedCategoryResponse> DeleteAsync(Guid categoryId)
        {
            await _categoryBusinessRules.CheckIfExistsById(categoryId);

            Category category = await _categoryDal.GetAsync(p => p.Id == categoryId);
            await _categoryDal.DeleteAsync(category);
            return _mapper.Map<DeletedCategoryResponse>(category);
        }

        [SecuredOperation("admin")]
        public async Task<UpdatedCategoryResponse> UpdateAsync(UpdateCategoryRequest updateCategoryRequest)
        {
            await _categoryBusinessRules.CheckIfExistsById(updateCategoryRequest.Id);

            Category category = await _categoryDal.GetAsync(p => p.Id == updateCategoryRequest.Id);
            _mapper.Map(updateCategoryRequest, category);
            category = await _categoryDal.UpdateAsync(category);
            return _mapper.Map<UpdatedCategoryResponse>(category);
        }

        public async Task<GetByIdCategoryResponse> GetByIdAsync(Guid categoryId)
        {
            await _categoryBusinessRules.CheckIfExistsById(categoryId);

            Category category = await _categoryDal.GetAsync(p => p.Id == categoryId, include: c => c.Include(c => c.Courses));
            return _mapper.Map<GetByIdCategoryResponse>(category);
        }
    }
}
