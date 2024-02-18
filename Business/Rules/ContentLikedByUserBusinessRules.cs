using Business.Abstracts;
using Business.Dtos.Content.Responses;
using Business.Dtos.User.Responses;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Messages;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class ContentLikedByUserBusinessRules : BaseBusinessRules<ContentLikedByUser>
    {
        IContentLikedByUserDal _contentLikedByUserDal;
        IUserService _userService;
        IContentService _contentService;
        public ContentLikedByUserBusinessRules(IContentLikedByUserDal contentLikedByUserDal, IUserService userService, IContentService contentService) : base(contentLikedByUserDal)
        {
            _contentLikedByUserDal = contentLikedByUserDal;
            _userService = userService;
            _contentService = contentService;
        }
        public async Task<ContentLikedByUser> CheckIfContentLikedByUserExists(Guid userId, Guid contentId)
        {
            ContentLikedByUser contentLikedByUser = await _contentLikedByUserDal.GetAsync(clbu => clbu.UserId == userId && clbu.ContentId == contentId);
            if (contentLikedByUser == null)
            {
                throw new BusinessException(BusinessCoreMessages.EntityNotFound);
            }
            return contentLikedByUser;
        }
        public async Task CheckIfUserExists(Guid userId)
        {
            GetByIdUserResponse user = await _userService.GetByIdAsync(userId);
            if (user == null)
            { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
        public async Task CheckIfContentExists(Guid contentId)
        {
            GetContentResponse content = await _contentService.GetByIdAsync(contentId);
            if (content == null)
            { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
    }
}
