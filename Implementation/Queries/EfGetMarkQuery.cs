using Application;
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
    public class EfGetMarkQuery : IGetMarkQuery
    {
        private readonly CactusContext _context;
        private readonly IMapper _mapper;

        public EfGetMarkQuery(CactusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 25;

        public string Name => "Get Mark";

        public MarkDto Execute(int search)
        {
            var mark = _context.Marks.Find(search);

            if (mark == null)
                throw new EntityNotFoundException(search, typeof(Mark));

            return _mapper.Map<MarkDto>(mark);
        }

       
    }
}
