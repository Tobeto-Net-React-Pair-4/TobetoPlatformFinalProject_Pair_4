using Business.Abstracts;
using Business.Dtos.Course.Responses;
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
    public class ContentBusinessRules : BaseBusinessRules<Content>
    {
        IContentDal _contentDal;
        ICourseService _courseService;
        public ContentBusinessRules(IContentDal contentDal, ICourseService courseService) : base(contentDal) 
        {
            _contentDal = contentDal;
            _courseService = courseService;
        }

        public async Task CheckIfCourseExists(Guid courseId)
        {
            GetByIdCourseResponse course = await _courseService.GetByIdAsync(courseId);
            if (course == null) { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
    }
}
