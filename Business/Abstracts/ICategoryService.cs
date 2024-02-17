using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Category.Requests;
using Business.Dtos.Category.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface ICategoryService
    {
        Task<Paginate<GetListCategoryResponse>> GetListAsync();
        Task<CreatedCategoryResponse> AddAsync(CreateCategoryRequest createCategoryRequest);
        Task<UpdatedCategoryResponse> UpdateAsync(UpdateCategoryRequest updateCategoryRequest);
        Task<DeletedCategoryResponse> DeleteAsync(Guid categoryId);
        Task<GetByIdCategoryResponse> GetByIdAsync(Guid categoryId);
    }
}