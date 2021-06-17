using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CategoryDto>
    {
        public CreateCategoryValidator(CactusContext context)
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage("Category {PropertyName} is required.")
               .DependentRules(() =>
               {
                   RuleFor(x => x.Name)
                   .Must(name => !context.Categories.Any(c => c.Name == name))
                   .WithMessage("Category with name of {PropertyValue} already exists in database");
               });
        }
    }
}
