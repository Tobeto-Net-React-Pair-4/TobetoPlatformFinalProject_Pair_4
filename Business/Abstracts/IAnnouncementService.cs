using Business.Dtos.Announcement.Requests;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.Course.Responses;
using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Business.Dtos.UserAnnouncement.Requests;
using Business.Dtos.UserAnnouncement.Responses;
using Business.Dtos.UserCourse.Requests;
using Business.Dtos.UserCourse.Responses;
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
        Task<CreatedAnnouncementResponse> AddAsync(CreateAnnouncementRequest createAnnouncementRequest);
        Task<UpdatedAnnouncementResponse> UpdateAsync(UpdateAnnouncementRequest updateAnnouncementRequest);
        Task<DeletedAnnouncementResponse> DeleteAsync(Guid announcementId);
        Task<Paginate<GetListAnnouncementResponse>> GetListByUserIdAsync(Guid userId);
        Task<CreatedUserAnnouncementResponse> AssignAnnouncementToUserAsync(CreateUserAnnouncementRequest createUserAnnouncementRequest);
    }
}
