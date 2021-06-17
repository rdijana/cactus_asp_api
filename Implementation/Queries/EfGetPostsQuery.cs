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
    public class EfGetPostsQuery : IGetPostsQuery
    {
        private readonly CactusContext _context;
        private readonly IMapper _mapper;

        public EfGetPostsQuery(CactusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 19;

        public string Name =>"Posts search";

        public PagedResponse<PostDto> Execute(PostSearch search)
        {
            var post = _context.Posts
               .Include(x => x.Comments)
               .ThenInclude(c => c.User)
               .Include(x => x.Marks)
               .Include(x => x.PostCategories)
               .ThenInclude(x => x.Category)
               .AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrWhiteSpace(search.Keyword))
            {

                post = post.Where(x => x.Title.ToLower().Contains(search.Keyword.ToLower()) ||
                  x.Description.ToLower().Contains(search.Keyword.ToLower()) ||
                  x.PostCategories.Any(y => y.Category.Name.ToLower().Contains(search.Keyword.ToLower())));
            }
            if (search.CategoryIds.Count()>0)
            {

                post = post.Where(x => x.PostCategories.Any(pc => search.CategoryIds.Contains(pc.CategoryId)));
            }
            return post.GetPageResponse<Post, PostDto>(search, _mapper);
        }
    }
}
