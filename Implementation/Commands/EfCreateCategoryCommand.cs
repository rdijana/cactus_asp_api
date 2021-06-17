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
    public class EfCreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly CactusContext _context;
        private readonly CreateCategoryValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateCategoryCommand(CactusContext context, IMapper mapper, CreateCategoryValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 1;

        public string Name => "Creating new category";

        public void Execute(CategoryDto request)
        {
            _validator.ValidateAndThrow(request);

            _context.Categories.Add(_mapper.Map<Category>(request));
            _context.SaveChanges();
        }
    }
}
