using Business.Abstracts;
using Business.Constants;
using Business.Dtos.ForeignLanguage.Requests;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Business.Rules
{
    public class ForeignLanguageBusinessRules : BaseBusinessRules
    {
        private readonly IForeignLanguageService _foreignLanguageService;

        public ForeignLanguageBusinessRules(IForeignLanguageService foreignLanguageService)
        {
            _foreignLanguageService = foreignLanguageService;
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
