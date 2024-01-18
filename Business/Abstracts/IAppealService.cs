using Business.Dtos.Announcement.Requests;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.Appeal.Requests;
using Business.Dtos.Appeal.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAppealService
    {
        Task<Paginate<GetListAppealResponse>> GetListAsync();
        Task<CreatedAppealResponse> AddAsync(CreateAppealRequest createAppealRequest);
        Task<UpdatedAppealResponse> UpdateAsync(UpdateAppealRequest updateAppealRequest);
        Task<DeletedAppealResponse> DeleteAsync(DeleteAppealRequest deleteAppealRequest);
    }
}
