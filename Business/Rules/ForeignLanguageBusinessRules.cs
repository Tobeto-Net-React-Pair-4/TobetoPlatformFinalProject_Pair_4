using Business.Abstracts;
using Business.Constants;
using Business.Dtos.ForeignLanguage.Requests;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules
{
    public class ForeignLanguageBusinessRules : BaseBusinessRules<ForeignLanguage>
    {
        private readonly IForeignLanguageService _foreignLanguageService;
        IForeignLanguageDal _foreignLanguageDal;

        public ForeignLanguageBusinessRules(IForeignLanguageService foreignLanguageService, IForeignLanguageDal foreignLanguageDal) : base(foreignLanguageDal)
        {
            _foreignLanguageService = foreignLanguageService;
            _foreignLanguageDal = foreignLanguageDal;
        }

        public async Task LanguageExists(CreateForeignLanguageRequest getByNameForeignLanguageRequest)
        {
            var result = await _foreignLanguageService.GetListAsync();
            foreach (var item in result.Items)
            {
                if (item.LanguageList == getByNameForeignLanguageRequest.LanguageList)
                {
                    throw new BusinessException(BusinessMessages.LanguageExists);

                }
            }
        }
    }
}
