using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class CreateUserValidator : AbstractValidator<UserDto>
    {
        public CreateUserValidator(CactusContext context)
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.FirstName)
                    .MaximumLength(40)
                    .WithMessage("First name can have a maximum 40 characters");
                });
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.LastName)
                    .MaximumLength(40)
                    .WithMessage("Last name can have a maximum 40 characters");
                });
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Email)
                    .EmailAddress()
                    .WithMessage("A valid email address is required.")
                    .DependentRules(() =>
                    {
                        RuleFor(x => x.Email)
                        .Must(email => !context.Users.Any(user => user.Email == email))
                        .WithMessage(dto => $"The email address of {dto.Email} already exists in the database");
                    });
                });
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .DependentRules(() => {
                    RuleFor(x => x.Password)
                    .MinimumLength(6);
                });
        }
    }
}