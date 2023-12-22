using Business.Dtos.Announcement.Requests;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAnnouncementService
    {
        Task<Paginate<GetListAnnouncementResponse>> GetListAsync();
        Task<CreatedAnnouncementResponse> Add(CreateAnnouncementRequest createAnnouncementRequest);
        Task<UpdatedAnnouncementResponse> Update(UpdateAnnouncementRequest updateAnnouncementRequest);
        Task<DeletedAnnouncementResponse> Delete(DeleteAnnouncementRequest deleteAnnouncementRequest);
    }
}
