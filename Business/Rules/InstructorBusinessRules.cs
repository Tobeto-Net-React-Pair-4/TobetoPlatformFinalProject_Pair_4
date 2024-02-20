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
    public class InstructorBusinessRules : BaseBusinessRules<Instructor>
    {
        private readonly IInstructorDal _instructorDal;
        private readonly IInstructorService _instructorService;
        public InstructorBusinessRules(IInstructorDal instructorDal, IInstructorService instructorService) : base(instructorDal)
        {
            _instructorDal = instructorDal;
            _instructorService = instructorService;
        }
    }
}
