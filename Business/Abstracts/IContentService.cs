using Business.Dtos.Content.Requests;
using Business.Dtos.Content.Responses;
using Business.Dtos.Course.Requests;
using Business.Dtos.Course.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IContentService
    {
        Task<Paginate<GetListContentResponse>> GetListAsync();
        Task<GetContentResponse> GetByIdAsync(Guid contentId);
        Task<CreatedContentResponse> AddAsync(CreateContentRequest createContentRequest);
        Task<UpdatedContentResponse> UpdateAsync(UpdateContentRequest updateContentRequest);
        Task<DeletedContentResponse> DeleteAsync(Guid contentId);
    }
}
