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
    public class EfUpdateMarkCommand : IUpdateMarkCommand
    {
        private readonly CactusContext _context;
        private readonly UpdateMarkValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfUpdateMarkCommand(CactusContext context, UpdateMarkValidator validator,IApplicationActor actor,IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
            _mapper = mapper;
        }

        public int Id => 14;

        public string Name => "Updating mark";

        public void Execute(MarkDto request)
        {
            request.UserId = _actor.Id;
            var mark = _context.Marks.Find(request.Id);

            if (mark == null)
            {
                throw new EntityNotFoundException(request.Id.Value, typeof(Mark));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, mark);
            _context.SaveChanges();
        }
    }
}
