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
    public class EfGetCommentsQuery : IGetCommentsQuery
    {
        private readonly CactusContext _context;
        private readonly IMapper _mapper;

        public EfGetCommentsQuery(CactusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 21;

        public string Name => "Comments search";

        public PagedResponse<CommentDto> Execute(CommentSearch search)
        {
            var comments =_context.Comments
                .Include(x => x.User)
               .AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrWhiteSpace(search.Keyword))
            {

                comments = comments.Where(x => x.Content.ToLower().Contains(search.Keyword.ToLower()) ||
                  x.User.FirstName.ToLower().Contains(search.Keyword.ToLower()) ||
                  x.User.LastName.ToLower().Contains(search.Keyword.ToLower())
                  );
            }
            
            return comments.GetPageResponse<Comment, CommentDto>(search, _mapper);
        }
    }
}
