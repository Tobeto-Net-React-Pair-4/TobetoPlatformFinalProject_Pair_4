using Business.Dtos.Appeal.Requests;
using Business.Dtos.Appeal.Responses;
using Business.Dtos.Experience.Requests;
using Business.Dtos.Experience.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IExperienceService
    {
        Task<Paginate<GetListExperienceResponse>> GetListAsync();
        Task<CreatedExperienceResponse> AddAsync(CreateExperienceRequest createExperienceRequest);
        Task<UpdatedExperienceResponse> UpdateAsync(UpdateExperienceRequest updateExperienceRequest);
        Task<DeletedExperienceResponse> DeleteAsync(Guid experienceId);
        Task<Paginate<GetListExperienceResponse>> GetListByUserIdAsync(Guid userId);
    }
}
