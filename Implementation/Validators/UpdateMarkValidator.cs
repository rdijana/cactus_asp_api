using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class UpdateMarkValidator : AbstractValidator<MarkDto>
    {
        public UpdateMarkValidator(CactusContext context)
        {
            RuleFor(x => x.Value)
                .GreaterThan(0)
                .WithMessage("Mark must be above 0.")
                .LessThanOrEqualTo(10)
                .WithMessage("Mark must be below 10.");
            RuleFor(x => x.PostId)
                .Must(id => context.Posts.Any(post => post.Id == id))
                .WithMessage((dto, id) => $"Post with an id of {id} doesn't exists in database.");
            RuleFor(x => x.UserId)
                .Must(id => context.Users.Any(user => user.Id == id))
                .WithMessage((dto, id) => $"User with an id of {id} doesn't exists in database.")
                .DependentRules(() => {
                    RuleFor(x => x.UserId)
                    .Must((dto, id) => context.Marks.Where(mark => mark.UserId == id).Select(mark => mark.Id).ToList().Contains((int)dto.Id))
                    .WithMessage("You can't update this mark.");
                });
        }
    }
}
