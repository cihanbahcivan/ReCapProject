using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).MinimumLength(2).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(2).NotEmpty();
            RuleFor(u => u.Email).EmailAddress().NotEmpty();
        }
    }
}
