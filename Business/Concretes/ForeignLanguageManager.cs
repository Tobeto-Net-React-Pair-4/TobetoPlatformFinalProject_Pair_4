using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Announcement.Requests;
using Business.Dtos.Announcement.Responses;
using Business.Dtos.ForeignLanguage.Requests;
using Business.Dtos.ForeignLanguage.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ForeignLanguageManager : IForeignLanguageService
    {
        private IForeignLanguageDal _foreignLanguageDal;
        private IMapper _mapper;
        public ForeignLanguageManager(IForeignLanguageDal foreignLanguageDal, IMapper mapper)
        {
            _foreignLanguageDal = foreignLanguageDal;
            _mapper = mapper;
        }

        public async Task<CreatedForeignLanguageResponse> AddAsync(CreateForeignLanguageRequest createForeignLanguageRequest)
        {
            ForeignLanguage foreignLanguage = _mapper.Map<ForeignLanguage>(createForeignLanguageRequest);
            foreignLanguage.Id = Guid.NewGuid();

            ForeignLanguage createdForeignLanguage = await _foreignLanguageDal.AddAsync(foreignLanguage);

            return _mapper.Map<CreatedForeignLanguageResponse>(createdForeignLanguage);
        }

        public async Task<DeletedForeignLanguageResponse> DeleteAsync(DeleteForeignLanguageRequest deleteForeignLanguageRequest)
        {
            ForeignLanguage foreignLanguage = await _foreignLanguageDal.GetAsync(p => p.Id == deleteForeignLanguageRequest.Id);
            await _foreignLanguageDal.DeleteAsync(foreignLanguage);
            return _mapper.Map<DeletedForeignLanguageResponse>(foreignLanguage);
        }

        public async Task<Paginate<GetListForeignLanguageResponse>> GetListAsync()
        {
            var data = await _foreignLanguageDal.GetListAsync(include: u => u.Include(u => u.User));
            return _mapper.Map<Paginate<GetListForeignLanguageResponse>>(data);
        }

        public async Task<UpdatedForeignLanguageResponse> UpdateAsync(UpdateForeignLanguageRequest updateForeignLanguageRequest)
        {
            ForeignLanguage foreignLanguage = await _foreignLanguageDal.GetAsync(p => p.Id == updateForeignLanguageRequest.Id);
            _mapper.Map(updateForeignLanguageRequest, foreignLanguage);
            await _foreignLanguageDal.UpdateAsync(foreignLanguage);
            return _mapper.Map<UpdatedForeignLanguageResponse>(foreignLanguage);
        }
    }
}
