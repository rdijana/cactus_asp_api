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
    public class EfGetLogsQuery : IGetLogsQuery
    {
        private readonly CactusContext _context;
        private readonly IMapper _mapper;

        public EfGetLogsQuery(CactusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 24;

        public string Name => "Search logs";

        public PagedResponse<LogDto> Execute(LogSearch search)
        {
            var query = _context.UseCaseLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword) && !string.IsNullOrWhiteSpace(search.Keyword))
                query = query.Where(x => x.Actor.ToLower().Contains(search.Keyword.ToLower()) ||
                                        x.UseCaseName.ToLower().Contains(search.Keyword.ToLower()));

            if (search.DateMin.HasValue)
                query = query.Where(x => x.CreatedAt >= search.DateMin);

            if (search.DateMax.HasValue)
                query = query.Where(x => x.CreatedAt <= search.DateMax);

            return query.GetPageResponse<UseCaseLog, LogDto>(search, _mapper);
        }
    }
}
