using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
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
        private ICourseService _courseService;
        private ICategoryDal _categoryDal;
        private IMapper _mapper;
        private CategoryBusinessRules _categoryBusinessRules;
        public CategoryManager(ICategoryDal categoryDal, IMapper mapper, CategoryBusinessRules categoryBusinessRules, ICourseService courseService, IInstructorService instructorService)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
            _courseService = courseService;
        }
        public async Task<CreatedCategoryResponse> AddAsync(CreateCategoryRequest createCategoryRequest)
        {
            await _categoryBusinessRules.MaximumCountIsTen();

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
        public async Task<DeletedCategoryResponse> DeleteAsync(DeleteCategoryRequest deleteCategoryRequest)
        {
            Category category = await _categoryDal.GetAsync(p => p.Id == deleteCategoryRequest.Id);
            await _categoryDal.DeleteAsync(category);
            return _mapper.Map<DeletedCategoryResponse>(category);
        }

        public async Task<UpdatedCategoryResponse> UpdateAsync(UpdateCategoryRequest updateCategoryRequest)
        {
            Category category = await _categoryDal.GetAsync(p => p.Id == updateCategoryRequest.Id);
            _mapper.Map(updateCategoryRequest, category);
            category = await _categoryDal.UpdateAsync(category);
            return _mapper.Map<UpdatedCategoryResponse>(category);
        }

        public async Task<GetByIdCategoryResponse> GetByIdAsync(GetByIdCategoryRequest getByIdCategoryRequest)
        {
            Category category = await _categoryDal.GetAsync(p => p.Id == getByIdCategoryRequest.Id, include: c => c.Include(c => c.Courses));

            return _mapper.Map<GetByIdCategoryResponse>(category);
        }
    }
}
