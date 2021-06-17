using Application.DataTransfer;
using Application.Queries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetCategoriesQuery : IGetCategoriesQuery
    {
        private readonly CactusContext _context;
        private readonly IMapper _mapper;

        public EfGetCategoriesQuery(CactusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 17;

        public string Name => "Category search";

        public PagedResponse<CategoryDto> Execute(CategorySearch search)
        {
            var query = _context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrWhiteSpace(search.Keyword))
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()));

            return query.GetPageResponse<Category, CategoryDto>(search, _mapper);
        }
    }
}
