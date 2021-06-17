using Application;
using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Commands
{
    public class EfUpdateCommentCommand : IUpdateCommentCommand
    {
        private readonly CactusContext _context;
        private readonly UpdateCommentValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;
        

        public EfUpdateCommentCommand(CactusContext context, UpdateCommentValidator validator,IApplicationActor actor, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
            _mapper = mapper;
        }

        public int Id => 11;

        public string Name => "Updating comment";

        public void Execute(CommentCreateDto request)
        {
            request.UserId = _actor.Id;
            var comment = _context.Comments.Find(request.Id);

            if (comment == null)
            {
                throw new EntityNotFoundException(request.Id.Value, typeof(Comment));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, comment);
            _context.SaveChanges();
        }
    }
}
