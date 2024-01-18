using Business.Dtos.Announcement.Requests;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.UserAnnouncement.Requests;
using Business.Dtos.UserAnnouncement.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserAnnouncementService
    {
        Task<Paginate<GetListUserAnnouncementResponse>> GetListAsync();
        Task<CreatedUserAnnouncementResponse> AddAsync(CreateUserAnnouncementRequest createUserAnnouncementRequest);
        Task<UpdatedUserAnnouncementResponse> UpdateAsync(UpdateUserAnnouncementRequest updateUserAnnouncementRequest);
        Task<DeletedUserAnnouncementResponse> DeleteAsync(DeleteUserAnnouncementRequest deleteUserAnnouncementRequest);

    }
}
