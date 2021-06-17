using Application;
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
    public class EfGetCommentQuery : IGetCommentQuery
    {
        private readonly CactusContext _context;
        private readonly IMapper _mapper;

        public EfGetCommentQuery(CactusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 20;

        public string Name => "Get comment";

        CommentDto IQuery<int, CommentDto>.Execute(int search)
        {
            var comment = _context.Comments.Include(x => x.User).FirstOrDefault(x => x.Id == search);

            if (comment == null)
                throw new EntityNotFoundException(search, typeof(Comment));

            return _mapper.Map<CommentDto>(comment);
        }
    }
}
