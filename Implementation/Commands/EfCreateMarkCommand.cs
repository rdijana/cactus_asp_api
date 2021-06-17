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
    public class EfCreateMarkCommand : ICreateMarkCommand
    {
        private readonly CactusContext _context;
        private readonly CreateMarkValidator _validator;
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfCreateMarkCommand(CactusContext context, CreateMarkValidator validator,IApplicationActor actor, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
            _mapper = mapper;
        }

        public int Id => 13;

        public string Name => "Creating mark for post";

        public void Execute(MarkDto request)
        {
            request.UserId = _actor.Id;
            _validator.ValidateAndThrow(request);

            _context.Marks.Add(_mapper.Map<Mark>(request));
            _context.SaveChanges();
        }
    }
}
