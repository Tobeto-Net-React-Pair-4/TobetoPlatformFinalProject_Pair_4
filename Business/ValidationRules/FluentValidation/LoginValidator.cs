using Business.Dtos.Auth.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(l => l.Email).NotEmpty();
            RuleFor(l => l.Email).EmailAddress();
            RuleFor(l => l.Password).NotEmpty();
            RuleFor(l => l.Password).MinimumLength(6);
        }
    }
}
