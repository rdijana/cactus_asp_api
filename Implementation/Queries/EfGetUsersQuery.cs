using Application.DataTransfer;
using Application.Queries;
using Application.Searches;
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
    public class EfGetUsersQuery : IGetUsersQuery
    {
        private readonly CactusContext _context;
        private readonly IMapper _mapper;

        public EfGetUsersQuery(CactusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id =>23;

        public string Name => "Search user";

        public PagedResponse<UserDto> Execute(UserSearch search)
        {
            var query = _context.Users.Include(x => x.UserUseCases).AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrWhiteSpace(search.Keyword))
            {

                query = query.Where(x => x.FirstName.ToLower().Contains(search.Keyword.ToLower()) ||
                                        x.LastName.ToLower().Contains(search.Keyword.ToLower()) ||
                                        x.Email.ToLower().Contains(search.Keyword.ToLower()));
            }
            if (search.UseCases.Count() > 0)
            {
                query = query.Where(x => x.UserUseCases.Any(uuc => search.UseCases.Contains(uuc.UseCaseId)));
            }

            return query.GetPageResponse<User, UserDto>(search, _mapper);
        }
    }
}
