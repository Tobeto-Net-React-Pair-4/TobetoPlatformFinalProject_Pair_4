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
    public interface IExperinceService
    {
        Task<Paginate<GetListExperienceResponse>> GetListAsync();
        Task<CreatedExperinceResponse> AddAsync(CreateExperinceRequest createExperinceRequest);
        Task<UpdatedExperinceResponse> UpdateAsync(UpdateExperinceRequest updateExperincelRequest);
        Task<DeletedExperinceResponse> DeleteAsync(DeleteExperinceRequest deleteExperinceRequest);
    }
}
