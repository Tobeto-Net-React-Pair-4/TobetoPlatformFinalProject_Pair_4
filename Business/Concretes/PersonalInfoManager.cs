using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.PersonalInfo.Requests;
using Business.Dtos.PersonalInfo.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class PersonalInfoManager : IPersonalInfoService
    {
        IPersonalInfoDal _personalInfoDal;
        IMapper _mapper;
        public PersonalInfoManager(IPersonalInfoDal personalInfoDal, IMapper mapper)
        {
            _personalInfoDal = personalInfoDal;
            _mapper = mapper;
        }
        public async Task<CreatedPersonalInfoResponse> AddAsync(CreatePersonalInfoRequest createPersonalInfoRequest)
        {
            PersonalInfo personalInfo = _mapper.Map<PersonalInfo>(createPersonalInfoRequest);
            PersonalInfo createdPersonalInfo = await _personalInfoDal.AddAsync(personalInfo);
            return _mapper.Map<CreatedPersonalInfoResponse>(createdPersonalInfo);
        }

        public async Task<DeletedPersonalInfoResponse> DeleteAsync(DeletePersonalInfoRequest deletePersonalInfoRequest)
        {
            PersonalInfo personalInfo = await _personalInfoDal.GetAsync(p => p.Id == deletePersonalInfoRequest.Id);
            PersonalInfo deletedPersonalInfo = await _personalInfoDal.DeleteAsync(personalInfo);
            return _mapper.Map<DeletedPersonalInfoResponse>(deletedPersonalInfo);
        }

        public async Task<GetPersonalInfoResponse> GetByIdAsync(GetPersonalInfoRequest getPersonalInfoRequest)
        {
            PersonalInfo personalInfo = await _personalInfoDal.GetAsync
                (p => p.Id == getPersonalInfoRequest.Id);
            return _mapper.Map<GetPersonalInfoResponse>(personalInfo);
        }

        public async Task<GetPersonalInfoResponse> GetByUserIdAsync(GetPersonalInfoRequest getPersonalInfoRequest)
        {
            PersonalInfo personalInfo = await _personalInfoDal.GetAsync
                (p => p.UserId == getPersonalInfoRequest.UserId);
            return _mapper.Map<GetPersonalInfoResponse>(personalInfo);
        }

        public async Task<Paginate<GetListPersonalInfoResponse>> GetListAsync()
        {
            var result = await _personalInfoDal.GetListAsync();
            return _mapper.Map<Paginate<GetListPersonalInfoResponse>>(result);
        }

        public async Task<UpdatedPersonalInfoResponse> UpdateAsync(UpdatePersonalInfoRequest updatePersonalInfoRequest)
        {
            PersonalInfo personalInfo = await _personalInfoDal.GetAsync(p => p.Id == updatePersonalInfoRequest.Id);
            _mapper.Map(updatePersonalInfoRequest, personalInfo);
            PersonalInfo updatedPersonalInfo = await _personalInfoDal.UpdateAsync(personalInfo);
            return _mapper.Map<UpdatedPersonalInfoResponse>(updatedPersonalInfo);
        }
    }
}
