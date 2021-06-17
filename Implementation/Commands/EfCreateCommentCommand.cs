using Application;
using Application.Commands;
using Application.DataTransfer;
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
    public class EfCreateCommentCommand : ICreateCommentCommand
    {
        private readonly CactusContext _context;
        private readonly CreateCommentValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;


        public EfCreateCommentCommand(CactusContext context, CreateCommentValidator validator, IMapper mapper,IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
            _actor = actor;
        }

        public int Id => 10;

        public string Name => "Creating new comment";

        public void Execute(CommentCreateDto request)
        {
            request.UserId = _actor.Id;
            _validator.ValidateAndThrow(request);

            _context.Comments.Add(_mapper.Map<Comment>(request));
            _context.SaveChanges();
        }
    }
}
