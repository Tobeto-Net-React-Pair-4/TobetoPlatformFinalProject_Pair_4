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
    public class LikeBusinessRules : BaseBusinessRules<Like>
    {
        private readonly ILikeDal _likeDal;
        private readonly ICourseService _courseService;

        public LikeBusinessRules(ILikeDal likeDal, ICourseService courseService) : base(likeDal) 
        {
            _likeDal = likeDal;
            _courseService = courseService;
        }
        public async Task CheckIfCourseExists(Guid courseId)
        {
            GetByIdCourseResponse course = await _courseService.GetByIdAsync(courseId);
            if (course == null)
            { throw new BusinessException(BusinessCoreMessages.EntityNotFound); }
        }
    }
}
