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
    public class EfGetPostQuery : IGetPostQuery
    {
        private readonly CactusContext _context;
        private readonly IMapper _mapper;

        public EfGetPostQuery(CactusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 18;

        public string Name =>"Get post";

        public PostDto Execute(int search)
        {
            var post = _context.Posts
                .Include(x => x.Comments)
                .ThenInclude(c => c.User)
                .Include(x => x.Marks)
                .Include(x => x.PostCategories)
                .ThenInclude(x => x.Category)
                .FirstOrDefault(x=>x.Id==search);

            if (post == null)
                throw new EntityNotFoundException(search, typeof(Post));

            return _mapper.Map<PostDto>(post);
        }
    }
}
