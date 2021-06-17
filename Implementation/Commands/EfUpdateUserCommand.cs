using Application;
using Application.Commands;
using Application.DataTransfer;
using Application.Exceptions;
using AutoMapper;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EfUpdateUserCommand : IUpdateUserCommand
    {
        private readonly CactusContext _context;
        private readonly UpdateUserValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateUserCommand(CactusContext context, UpdateUserValidator validator,IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 8;

        public string Name => "Updating user";

        public void Execute(UserDto request)
        {
            var user = _context.Users.Include(u => u.UserUseCases).FirstOrDefault(u => u.Id == request.Id);
           

            if (user == null)
            {
                throw new EntityNotFoundException(request.Id.Value, typeof(User));
            }

            _validator.ValidateAndThrow(request);

            _mapper.Map(request, user);

            if (!string.IsNullOrWhiteSpace(request.Password))
            {

                user.Password = HashHelper.ConvertPasswordFormat(request.Password, 0xFF); ;
            }
            

            user.UserUseCases.Where(uuc => !request.AllowedUseCases.Contains(uuc.UseCaseId)).ToList().ForEach(uc => user.UserUseCases.Remove(uc));
            
            var existingUserUseCaseIds = user.UserUseCases.Select(uuc => uuc.UseCaseId);
            
            request.AllowedUseCases.Except(existingUserUseCaseIds).ToList().ForEach(useCaseId => _context.UserUseCases.Add(new UserUseCase
            {
                User = user,
                UseCaseId = useCaseId
            }));

            user.ModifiedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
