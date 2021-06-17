using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class UpdatePostValidator : AbstractValidator<PostCreateDto>
    {
        public UpdatePostValidator(CactusContext context)
        {
            RuleFor(p => p.Title).NotEmpty()
                .WithMessage("Post {PropertyName} is required.").
                DependentRules(() =>
                {
                    RuleFor(p => p.Title)
                    .Must((dto, title) => !context.Posts.Any(p => p.Title == title && p.Id != dto.Id))
                    .WithMessage(dto => $"Post with name {dto.Title} already exists in database.");
                });

            RuleFor(p => p.Description).NotEmpty()
                .WithMessage("Post {PropertyName} is required.");

            RuleFor(p => p.Content).NotEmpty()
                .WithMessage("Post {PropertyName} is required.");

            RuleFor(p => p.CategoryIds).NotEmpty()
                .WithMessage("Category is required.")
                .DependentRules(() => {
                    RuleForEach(p => p.CategoryIds).Must(id => context.Categories.Any(c => c.Id == id))
                    .WithMessage((dto, id) => $"Category with an id of {id} doesn't exists in database.");
                });
        }
    }
}
