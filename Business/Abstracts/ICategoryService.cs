using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Category.Requests;
using Business.Dtos.Category.Response;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface ICategoryService
    {
        Task<Paginate<GetListedCategoryResponse>> GetListAsync();
        Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest);
        Task<UpdatedCategoryResponse> Update(UpdateCategoryRequest updateCategoryRequest);
        Task<DeletedCategoryResponse> Delete(DeleteCategoryRequest deleteCategoryRequest);
    }
}