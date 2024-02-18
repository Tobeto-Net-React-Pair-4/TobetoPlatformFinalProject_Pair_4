using Business.Constants;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules
{

    public class SocialMediaBusinessRules : BaseBusinessRules<SocialMedia>
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaBusinessRules(ISocialMediaDal socialMediaDal) : base(socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public async Task MaximumCountIsThree()
        {
            var result = await _socialMediaDal.GetListAsync();

            if (result.Count > 3)
            {
                throw new BusinessException(BusinessMessages.SocialMediaLimit);
            }
        }
    }
}
