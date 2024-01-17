using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Education.Requests;
using Business.Dtos.Education.Responses;
using Business.Dtos.Instructor.Requests;
using Business.Dtos.Instructor.Responses;
using Business.Dtos.UserAnnouncement.Requests;
using Business.Dtos.UserAnnouncement.Responses;
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
    public class EducationManager : IEducationService
    {
        private IEducationDal _educationDal;
        private IMapper _mapper;
        public EducationManager(IEducationDal educationDal, IMapper mapper)
        {
            _educationDal = educationDal;
            _mapper = mapper;
        }

        public async Task<CreatedEducationResponse> AddAsync(CreateEducationRequest createEducationRequest)
        {
            Education education = _mapper.Map<Education>(createEducationRequest);
            var createdEducation = await _educationDal.AddAsync(education);
            CreatedEducationResponse result = _mapper.Map<CreatedEducationResponse>(education);
            return result;
        }

        public async Task<DeletedEducationResponse> DeleteAsync(DeleteEducationRequest deletEducationResquest)
        {
            Education education = await _educationDal.GetAsync(p => p.Id == deletEducationResquest.Id);
            await _educationDal.DeleteAsync(education);
            return _mapper.Map<DeletedEducationResponse>(education);
        }

        public async Task<GetEducationResponse> GetByIdAsync(GetByIdEducationRequest getByIdEducationRequest)
        {
            var result = await _educationDal.GetAsync(e => e.Id == getByIdEducationRequest.Id);
            return _mapper.Map<GetEducationResponse>(result);
        }

        public async Task<Paginate<GetListEducationResponse>> GetListAsync()
        {
            var result = await _educationDal.GetListAsync();
            return _mapper.Map<Paginate<GetListEducationResponse>>(result);
        }

        public async Task<UpdatedEducationResponse> UpdateAsync(UpdateEducationRequest updateEducationRequest)
        {
            Education education = _mapper.Map<Education>(updateEducationRequest);
            var updatedEducation = await _educationDal.UpdateAsync(education);
            UpdatedEducationResponse updatedEducationResponse = _mapper.Map<UpdatedEducationResponse>(updatedEducation);
            return updatedEducationResponse;
        }
    }
}
