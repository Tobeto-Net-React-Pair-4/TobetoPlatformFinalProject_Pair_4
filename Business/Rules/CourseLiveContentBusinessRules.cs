using Business.Abstracts;
using Business.Dtos.Course.Responses;
using Business.Dtos.LiveContent.Responses;
using Business.Dtos.User.Responses;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Messages;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class CourseLiveContentBusinessRules : BaseBusinessRules<CourseLiveContent>
    {
        ICourseLiveContentDal _courseLiveContentDal;
        ICourseService _courseService;
        ILiveContentService _liveContentService;
        public CourseLiveContentBusinessRules
            (ICourseLiveContentDal courseLiveContentDal, ICourseService courseService, ILiveContentService liveContentService) : base(courseLiveContentDal)
        {
            _courseLiveContentDal = courseLiveContentDal;
            _courseService = courseService;
            _liveContentService = liveContentService;
        }
        public async Task<CourseLiveContent> CheckIfCourseLiveContentExists(Guid courseId, Guid liveContentId)
        {
            CourseLiveContent courseLiveContent = await _courseLiveContentDal.GetAsync
                (clc => clc.CourseId == courseId && clc.LiveContentId == liveContentId);
            if (courseLiveContent == null)
            {
                throw new BusinessException(BusinessCoreMessages.EntityNotFound);
            }
            return courseLiveContent;
        }
        public async Task CheckIfLiveContentExists(Guid liveContentId)
        {
            GetLiveContentResponse liveContent = await _liveContentService.GetByIdAsync(liveContentId);
            if (liveContent == null)
            { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
        public async Task CheckIfCourseExists(Guid courseId)
        {
            GetByIdCourseResponse course = await _courseService.GetByIdAsync(courseId);
            if (course == null)
            { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
    }
}
