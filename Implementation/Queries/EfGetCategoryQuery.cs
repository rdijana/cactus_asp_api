using Application.DataTransfer;
using Application.Exceptions;
using Application.Queries;
using AutoMapper;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Queries
{
    public class EfGetCategoryQuery : IGetCategoryQuery
    {
        private readonly CactusContext _context;
        private readonly IMapper _mapper;

        public EfGetCategoryQuery(CactusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 17;

        public string Name => "Get category";

        public CategoryDto Execute(int search)
        {
            var category = _context.Categories.Find(search);

            if (category == null)
                throw new EntityNotFoundException(search, typeof(Category));

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
