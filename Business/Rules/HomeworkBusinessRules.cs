using Business.Abstracts;
using Business.Dtos.Course.Responses;
using Business.Dtos.LiveContent.Responses;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Messages;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Rules
{
    public class HomeworkBusinessRules : BaseBusinessRules<Homework>
    {
        IHomeworkDal _homeworkDal;
        ICourseService _courseService;
        ILiveContentService _liveContentService;
        public HomeworkBusinessRules(IHomeworkDal homeworkDal, ILiveContentService liveContentService, ICourseService courseService) : base(homeworkDal)
        {
            _homeworkDal = homeworkDal;
            _liveContentService = liveContentService;
            _courseService = courseService;
        }
        public async Task CheckIfCourseExists(Guid courseId)
        {
            GetByIdCourseResponse course = await _courseService.GetByIdAsync(courseId);
            if (course == null)
            { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
        public async Task CheckIfLiveContentExists(Guid liveContentId)
        {
            GetLiveContentResponse liveContent = await _liveContentService.GetByIdAsync(liveContentId);
            if (liveContent == null) { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
    }
}
