using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries;
using AutoMapper;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetUserQuery : IGetUserQuery
    {
        private readonly CactusContext _context;
        private readonly IMapper _mapper;

        public EfGetUserQuery(CactusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 22;

        public string Name => "Get user";

        public UserDto Execute(int search)
        {
            var user = _context.Users.Include(x => x.UserUseCases).FirstOrDefault(x => x.Id == search);

            if (user == null)
                throw new EntityNotFoundException(search, typeof(User));

            return _mapper.Map<UserDto>(user);
        }
    }
}
