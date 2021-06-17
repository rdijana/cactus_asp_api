using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class CreateMarkValidator : AbstractValidator<MarkDto>
    {
        public CreateMarkValidator(CactusContext context)
        {
            RuleFor(x => x.Value)
                .GreaterThan(0)
                .WithMessage("Mark must be above 0.")
                .LessThanOrEqualTo(10)
                .WithMessage("Mark must be below 10.");
            RuleFor(x => x.PostId)
                .Must(id => context.Posts.Any(post => post.Id == id))
                .WithMessage(id => $"Post with an id of {id} doesn't exists in database.");
            RuleFor(x => x.UserId)
                .Must(id => context.Users.Any(user => user.Id == id))
                .WithMessage(id => $"User with an id of {id} doesn't exists in database.")
                .DependentRules(() => {
                    RuleFor(x => x.UserId)
                    .Must((dto, id) => !context.Marks.Any(r => r.UserId == id && r.PostId == dto.PostId))
                    .WithMessage("You can't leave a rating for the same post twice");
                });
        }
    }
}
