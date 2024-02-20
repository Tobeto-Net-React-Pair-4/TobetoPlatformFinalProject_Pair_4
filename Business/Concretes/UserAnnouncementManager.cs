using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.Course.Responses;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.UserAnnouncement.Requests;
using Business.Dtos.UserAnnouncement.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    internal class UserAnnouncementManager : IUserAnnouncementService
    {
        private IUserAnnouncementDal _userAnnouncementDal;
        private IMapper _mapper;
        public UserAnnouncementManager(IUserAnnouncementDal userAnnouncementDal, IMapper mapper)
        {
            _userAnnouncementDal = userAnnouncementDal;
            _mapper = mapper;
        }

        [SecuredOperation("admin")]
        public async Task<CreatedUserAnnouncementResponse> AddAsync(CreateUserAnnouncementRequest createUserAnnouncementRequest)
        {
            UserAnnouncement userAnnouncement = _mapper.Map<UserAnnouncement>(createUserAnnouncementRequest);
            userAnnouncement.Id = Guid.NewGuid();

            UserAnnouncement createdUserAnnouncement = await _userAnnouncementDal.AddAsync(userAnnouncement);

            return _mapper.Map<CreatedUserAnnouncementResponse>(createdUserAnnouncement);
        }

        [SecuredOperation("admin")]
        public async Task<DeletedUserAnnouncementResponse> DeleteAsync(DeleteUserAnnouncementRequest deleteUserAnnouncementRequest)
        {
            UserAnnouncement userAnnouncement = await _userAnnouncementDal.GetAsync(p => p.Id == deleteUserAnnouncementRequest.Id);
            await _userAnnouncementDal.DeleteAsync(userAnnouncement);
            return _mapper.Map<DeletedUserAnnouncementResponse>(userAnnouncement);
        }

        public async Task<Paginate<GetListUserAnnouncementResponse>> GetListAsync()
        {
            var data = await _userAnnouncementDal.GetListAsync();
            return _mapper.Map<Paginate<GetListUserAnnouncementResponse>>(data);
        }

        public async Task<Paginate<GetListAnnouncementResponse>> GetListByUserIdAsync(Guid userId)
        {
            var data = await _userAnnouncementDal.GetListAsync(uc => uc.UserId == userId,
                include: uc => uc.Include(uc => uc.Announcement));
            return _mapper.Map<Paginate<GetListAnnouncementResponse>>(data);
        }
    }
}
