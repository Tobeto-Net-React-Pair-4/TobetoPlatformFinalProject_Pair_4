using Business.Abstracts;
using Business.Constants;
using Business.Dtos.ForeignLanguage.Requests;
using Business.Dtos.User.Responses;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Messages;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules
{
    public class ForeignLanguageBusinessRules : BaseBusinessRules<ForeignLanguage>
    {
        private readonly IForeignLanguageService _foreignLanguageService;
        IForeignLanguageDal _foreignLanguageDal;
        IUserService _userService;

        public ForeignLanguageBusinessRules
            (IForeignLanguageService foreignLanguageService, IForeignLanguageDal foreignLanguageDal, IUserService userService) : base(foreignLanguageDal)
        {
            _foreignLanguageService = foreignLanguageService;
            _foreignLanguageDal = foreignLanguageDal;
            _userService = userService;
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
        public async Task CheckIfUserExists(Guid userId)
        {
            GetByIdUserResponse user = await _userService.GetByIdAsync(userId);
            if (user == null)
            { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
    }
}
