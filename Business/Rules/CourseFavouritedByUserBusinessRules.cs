using Business.Abstracts;
using Core.Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class CourseFavouritedByUserBusinessRules : BaseBusinessRules<CourseFavouritedByUser>
    {
        ICourseFavouritedByUserDal _courseFavouritedByUserDal;
        ICourseService _courseService;
        IUserService _userService;
        public CourseFavouritedByUserBusinessRules
            (ICourseFavouritedByUserDal courseFavouritedByUserDal, IUserService userService, ICourseService courseService) : base(courseFavouritedByUserDal)
        {
            _courseFavouritedByUserDal = courseFavouritedByUserDal;
            _userService = userService;
            _courseService = courseService;
        }
    }
}
