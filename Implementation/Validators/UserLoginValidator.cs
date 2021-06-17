using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class UserLoginValidator : AbstractValidator<UserLoginRequest>
    {
        public UserLoginValidator(CactusContext context)
        {
            RuleFor(x => x.Email)
               .NotEmpty()
               .WithMessage("Email is required.")
               .DependentRules(() => {
                   RuleFor(x => x.Email)
                   .Must(email => context.Users.Any(u => u.Email == email))
                   .WithMessage("User with an email of {PropertyValue} doesn't exist in database");
               });
            RuleFor(x => x.Password)
               .NotEmpty()
               .WithMessage("Password is required.")
               .DependentRules(() => {
                   RuleFor(x => x.Password)
                   .Must(password => context.Users.Any(u => u.Password == HashHelper.ConvertPasswordFormat(password, 0xFF)))
                   .WithMessage("User with this password doesn't exist in database");
               }); ;
        }
    }
}
