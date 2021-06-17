using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class UpdateCommentValidator : AbstractValidator<CommentCreateDto>
    {
        public UpdateCommentValidator(CactusContext context)
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Comment can't be empty.");
            RuleFor(x => x.UserId)
                .Must(id => context.Users.Any(user => user.Id == id))
                .WithMessage((dto, id) => $"User with an id of {id} doesn't exists in database.")
                .DependentRules(() => {
                    RuleFor(x => x.UserId)
                    .Must((dto, id) => context.Comments.Where(comment => comment.UserId == id).Select(comment => comment.Id).ToList().Contains((int)dto.Id))
                    .WithMessage("You can't update this comment.");
                });
        }
    }
}
