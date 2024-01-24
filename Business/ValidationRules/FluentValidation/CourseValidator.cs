using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Course.Requests;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Identity.Client;

namespace Business.ValidationRules.FluentValidation
{
    public class CourseValidator : AbstractValidator<CreateCourseRequest>
    {
        public CourseValidator()
        {
            RuleFor(p => p.InstructorId).NotEmpty();
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Producer).NotEmpty();
            RuleFor(p => p.Status).NotEmpty();
            

        }
    }
}
