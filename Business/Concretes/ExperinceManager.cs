using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.Experience.Requests;
using Business.Dtos.Experience.Responses;
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
    public class ExperinceManager : IExperinceService
    {
        private IExperienceDal _experinceDal;
        private IMapper _mapper;
        public ExperinceManager(IExperienceDal experienceDal, IMapper mapper)
        {
            _experinceDal = experienceDal;
            _mapper = mapper;
        }
        public async Task<CreatedExperinceResponse> AddAsync(CreateExperinceRequest createExperinceRequest)
        {
            Experience experince = _mapper.Map<Experience>(createExperinceRequest);
            experince.Id = Guid.NewGuid(); ;

            Experience createdExperince = await _experinceDal.AddAsync(experince);
            return _mapper.Map<CreatedExperinceResponse>(createdExperince);
        }

        public async Task<DeletedExperinceResponse> DeleteAsync(DeleteExperinceRequest deleteExperinceRequest)
        {
            Experience experince = await _experinceDal.GetAsync(p => p.Id == deleteExperinceRequest.Id);
            await _experinceDal.DeleteAsync(experince);
            return _mapper.Map<DeletedExperinceResponse>(experince);
        }

        public async Task<Paginate<GetListExperienceResponse>> GetListAsync()
        {
            var data = await _experinceDal.GetListAsync(include: u => u.Include(u => u.User));
            return _mapper.Map<Paginate<GetListExperienceResponse>>(data);
        }

        public async Task<UpdatedExperinceResponse> UpdateAsync(UpdateExperinceRequest updateExperincelRequest)
        {

            Experience experince = await _experinceDal.GetAsync(p => p.Id == updateExperincelRequest.Id);
            _mapper.Map(updateExperincelRequest, experince);
            await _experinceDal.UpdateAsync(experince);
            return _mapper.Map<UpdatedExperinceResponse>(experince);
        }
    }
}
