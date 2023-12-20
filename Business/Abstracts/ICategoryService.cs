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
        Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest);
        Task<UpdatedCategoryResponse> Update(UpdateCategoryRequest updateCategoryRequest);
        Task<DeletedCategoryResponse> Delete(DeleteCategoryRequest deleteCategoryRequest);
        Task<GetByIdCategoryResponse> GetById(GetByIdCategoryRequest getByIdCategoryRequest);
    }
}