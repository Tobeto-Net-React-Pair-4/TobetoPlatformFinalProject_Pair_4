using Business.Constants;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules
{

    public class SocialMediaBusinessRules : BaseBusinessRules
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaBusinessRules(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public async Task MaximumCountIsTen()
        {
            var result = await _socialMediaDal.GetListAsync();

            if (result.Count > 3)
            {
                throw new Exception(BusinessMessages.CategoryLimit);
            }
        }
    }
}
