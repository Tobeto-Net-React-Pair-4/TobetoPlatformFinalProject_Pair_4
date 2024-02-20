using AutoMapper;
using Business.Abstracts;
using Business.Dtos.ForeignLanguage.Requests;
using Business.Dtos.ForeignLanguage.Responses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class ForeignLanguageManager : IForeignLanguageService
    {
        private IForeignLanguageDal _foreignLanguageDal;
        private IMapper _mapper;
        private ForeignLanguageBusinessRules _foreignLanguageBusinessRules;

        public ForeignLanguageManager(IForeignLanguageDal foreignLanguageDal, IMapper mapper, ForeignLanguageBusinessRules foreignLanguageBusinessRules)
        {
            _foreignLanguageDal = foreignLanguageDal;
            _mapper = mapper;
            _foreignLanguageBusinessRules = foreignLanguageBusinessRules;
        }

        public async Task<CreatedForeignLanguageResponse> AddAsync(CreateForeignLanguageRequest createForeignLanguageRequest)
        {
            await _foreignLanguageBusinessRules.LanguageExists(createForeignLanguageRequest);
            await _foreignLanguageBusinessRules.CheckIfUserExists(createForeignLanguageRequest.UserId);

            ForeignLanguage foreignLanguage = _mapper.Map<ForeignLanguage>(createForeignLanguageRequest);
            foreignLanguage.Id = Guid.NewGuid();

            ForeignLanguage createdForeignLanguage = await _foreignLanguageDal.AddAsync(foreignLanguage);

            return _mapper.Map<CreatedForeignLanguageResponse>(createdForeignLanguage);
        }

        public async Task<DeletedForeignLanguageResponse> DeleteAsync(Guid foreignLanguageId)
        {
            await _foreignLanguageBusinessRules.CheckIfExistsById(foreignLanguageId);

            ForeignLanguage foreignLanguage = await _foreignLanguageDal.GetAsync(p => p.Id == foreignLanguageId);
            await _foreignLanguageDal.DeleteAsync(foreignLanguage);
            return _mapper.Map<DeletedForeignLanguageResponse>(foreignLanguage);
        }

        public async Task<GetByIdForeignLanguageResponse> GetByIdAsync(Guid foreignLanguageId)
        {
            await _foreignLanguageBusinessRules.CheckIfExistsById(foreignLanguageId);

            ForeignLanguage foreignLanguage = await _foreignLanguageDal.GetAsync(p => p.Id == foreignLanguageId);
            return _mapper.Map<GetByIdForeignLanguageResponse>(foreignLanguage);
        }

        public async Task<Paginate<GetListForeignLanguageResponse>> GetListAsync()
        {
            var data = await _foreignLanguageDal.GetListAsync(include: u => u.Include(u => u.User));
            return _mapper.Map<Paginate<GetListForeignLanguageResponse>>(data);
        }

        public async Task<UpdatedForeignLanguageResponse> UpdateAsync(UpdateForeignLanguageRequest updateForeignLanguageRequest)
        {
            await _foreignLanguageBusinessRules.CheckIfUserExists(updateForeignLanguageRequest.UserId);
            await _foreignLanguageBusinessRules.CheckIfExistsById(updateForeignLanguageRequest.Id);

            ForeignLanguage foreignLanguage = await _foreignLanguageDal.GetAsync(p => p.Id == updateForeignLanguageRequest.Id);
            _mapper.Map(updateForeignLanguageRequest, foreignLanguage);
            await _foreignLanguageDal.UpdateAsync(foreignLanguage);
            return _mapper.Map<UpdatedForeignLanguageResponse>(foreignLanguage);
        }
    }
}
