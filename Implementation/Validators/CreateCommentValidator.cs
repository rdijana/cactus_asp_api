using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Validators
{
    public class CreateCommentValidator : AbstractValidator<CommentCreateDto>
    {
        public CreateCommentValidator(CactusContext context)
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Comment can't be empty.");
            RuleFor(x => x.PostId)
                .Must(id => 
                     context.Posts.Any(post => post.Id == id
                    ))
                .WithMessage((dto, id) => $"Post with an id of {id} doesn't exists in database.");
            RuleFor(x => x.UserId)
                .Must(id =>  
                      context.Users.Any(user => user.Id == id
                ))
                .WithMessage((dto, id) => $"User with an id of {id} doesn't exists in database.");
        }
    }
}
