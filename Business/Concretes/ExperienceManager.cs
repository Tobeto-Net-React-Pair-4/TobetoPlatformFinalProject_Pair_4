using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.Experience.Requests;
using Business.Dtos.Experience.Responses;
using Business.Rules;
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
    public class ExperienceManager : IExperienceService
    {
        private IExperienceDal _experienceDal;
        private IMapper _mapper;
        private ExperienceBusinessRules _experienceBusinessRules;
        public ExperienceManager(IExperienceDal experienceDal, IMapper mapper, ExperienceBusinessRules experienceBusinessRules)
        {
            _experienceDal = experienceDal;
            _mapper = mapper;
            _experienceBusinessRules = experienceBusinessRules;
        }
        public async Task<CreatedExperienceResponse> AddAsync(CreateExperienceRequest createExperienceRequest)
        {
            await _experienceBusinessRules.CheckIfUserExists(createExperienceRequest.UserId);

            Experience experience = _mapper.Map<Experience>(createExperienceRequest);
            experience.Id = Guid.NewGuid();

            Experience createdExperience = await _experienceDal.AddAsync(experience);
            return _mapper.Map<CreatedExperienceResponse>(createdExperience);
        }

        public async Task<DeletedExperienceResponse> DeleteAsync(Guid experienceId)
        {
            await _experienceBusinessRules.CheckIfExistsById(experienceId);

            Experience experience = await _experienceDal.GetAsync(p => p.Id == experienceId);
            await _experienceDal.DeleteAsync(experience);
            return _mapper.Map<DeletedExperienceResponse>(experience);
        }

        public async Task<Paginate<GetListExperienceResponse>> GetListAsync()
        {
            var data = await _experienceDal.GetListAsync(include: u => u.Include(u => u.User));
            return _mapper.Map<Paginate<GetListExperienceResponse>>(data);
        }

        public async Task<UpdatedExperienceResponse> UpdateAsync(UpdateExperienceRequest updateExperienceRequest)
        {
            await _experienceBusinessRules.CheckIfExistsById(updateExperienceRequest.Id);
            await _experienceBusinessRules.CheckIfUserExists(updateExperienceRequest.UserId);

            Experience experience = await _experienceDal.GetAsync(p => p.Id == updateExperienceRequest.Id);
            _mapper.Map(updateExperienceRequest, experience);
            await _experienceDal.UpdateAsync(experience);
            return _mapper.Map<UpdatedExperienceResponse>(experience);
        }
        public async Task<Paginate<GetListExperienceResponse>> GetListByUserIdAsync(Guid userId)
        {
            await _experienceBusinessRules.CheckIfUserExists(userId);

            var data = await _experienceDal.GetListAsync(e => e.UserId == userId, include: u => u.Include(u => u.User));
            return _mapper.Map<Paginate<GetListExperienceResponse>>(data);
        }
    }
}
