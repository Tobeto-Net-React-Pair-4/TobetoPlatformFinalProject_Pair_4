using AutoMapper;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class AnnouncementManager : IAnnouncementService
    {
        private IAnnouncementDal _announcementDal;
        private IMapper _mapper;
        private AnnouncementBusinessRules _announcementBusinessRules;
        public AnnouncementManager
            (IAnnouncementDal announcementDal, IMapper mapper, AnnouncementBusinessRules announcementBusinessRules)
        {
            _announcementDal = announcementDal;
            _mapper = mapper;
            _announcementBusinessRules = announcementBusinessRules;
        }

        [SecuredOperation("admin")]
        public async Task<CreatedAnnouncementResponse> AddAsync(CreateAnnouncementRequest createAnnouncementRequest)
        {
            Announcement announcement = _mapper.Map<Announcement>(createAnnouncementRequest);
            announcement.Id = Guid.NewGuid();

            Announcement createdAnnouncement = await _announcementDal.AddAsync(announcement);

            return _mapper.Map<CreatedAnnouncementResponse>(createdAnnouncement);
        }

        [SecuredOperation("admin")]
        public async Task<DeletedAnnouncementResponse> DeleteAsync(Guid announcementId)
        {
            await _announcementBusinessRules.CheckIfExistsById(announcementId);

            Announcement announcement = await _announcementDal.GetAsync(p => p.Id == announcementId);
            await _announcementDal.DeleteAsync(announcement);
            return _mapper.Map<DeletedAnnouncementResponse>(announcement);
        }

        public async Task<Paginate<GetListAnnouncementResponse>> GetListAsync()
        {
            var data = await _announcementDal.GetListAsync();
            return _mapper.Map<Paginate<GetListAnnouncementResponse>>(data);
        }

        [SecuredOperation("admin")]
        public async Task<UpdatedAnnouncementResponse> UpdateAsync(UpdateAnnouncementRequest updateAnnouncementRequest)
        {
            await _announcementBusinessRules.CheckIfExistsById(updateAnnouncementRequest.Id);

            Announcement announcement = await _announcementDal.GetAsync(p => p.Id == updateAnnouncementRequest.Id);
            _mapper.Map(updateAnnouncementRequest, announcement);
            await _announcementDal.UpdateAsync(announcement);
            return _mapper.Map<UpdatedAnnouncementResponse>(announcement);
        }
    }
}
