using Business.Abstracts;
using Business.Dtos.AsyncContent.Responses;
using Business.Dtos.Content.Responses;
using Business.Dtos.Course.Responses;
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
    public class CourseAsyncContentBusinessRules : BaseBusinessRules<CourseAsyncContent>
    {
        ICourseAsyncContentDal _courseAsyncContentDal;
        IAsyncContentService _asyncContentService;
        ICourseService _courseService;
        public CourseAsyncContentBusinessRules
            (ICourseAsyncContentDal courseAsyncContentDal, IAsyncContentService asyncContentService, ICourseService courseService) : base(courseAsyncContentDal)
        {
            _courseAsyncContentDal = courseAsyncContentDal;
            _asyncContentService = asyncContentService;
            _courseService = courseService;
        }
        public async Task<CourseAsyncContent> CheckIfCourseAsyncContentExists(Guid courseId, Guid asyncContentId)
        {
            CourseAsyncContent courseAsyncContent = await _courseAsyncContentDal.GetAsync
                (cac => cac.CourseId == courseId && cac.AsyncContentId == asyncContentId);
            if (courseAsyncContent == null)
            {
                throw new BusinessException(BusinessCoreMessages.EntityNotFound);
            }
            return courseAsyncContent;
        }
        public async Task CheckIfAsyncContentExists(Guid asyncContentId)
        {
            GetAsyncContentResponse asyncContent = await _asyncContentService.GetByIdAsync(asyncContentId);
            if (asyncContent == null)
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
