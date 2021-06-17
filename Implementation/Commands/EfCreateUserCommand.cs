using Application.Commands;
using Application.DataTransfer;
using Application.Email;
using AutoMapper;
using DataAccess;
using Domain;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Commands
{
    public class EfCreateUserCommand : ICreateUserCommand
    {

        private readonly CactusContext _context;
        private readonly CreateUserValidator _validator;
        private readonly IMapper _mapper;

        private readonly IEmailSender _sender;

        public EfCreateUserCommand(CactusContext context, CreateUserValidator validator, IMapper mapper, IEmailSender sender)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
            _sender = sender;

        }

        public int Id => 7;

        public string Name => "Creating user";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);

            var user = _mapper.Map<User>(request);

            user.Password = HashHelper.ConvertPasswordFormat(request.Password, 0xFF);

            var userUseCases = new List<int> {10,11,12,13,14,15,18,19};

            userUseCases.ForEach(useCase => _context.UserUseCases.Add(new UserUseCase
            {
                User = user,
                UseCaseId = useCase
            }));

            _context.Users.Add(user);
            _context.SaveChanges();

            _sender.Send(new MailDto
            {
                Content = "<h1>You have successfully registered on the Cactus blog.</h1>",
                SendTo = request.Email,
                Subject = "Registration"
            });
        }
    }
}
