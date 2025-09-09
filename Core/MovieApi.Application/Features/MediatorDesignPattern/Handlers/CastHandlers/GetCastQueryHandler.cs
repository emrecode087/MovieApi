using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Persistence.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandler
{
    public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
    {
        private readonly MovieContext _context;

        public GetCastQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
        {
            // ChangeTracker kullanılmayacak, performans için AsNoTracking
            return await _context.Casts
                .AsNoTracking()
                .Select(x => new GetCastQueryResult
                {
                    Biography = x.Biography,
                    CastId = x.CastId,
                    Name = x.Name,
                    Surname = x.Surname,
                    Title = x.Title,
                    Overview = x.Overview,
                    ImageUrl = x.ImageUrl
                })
                .ToListAsync(cancellationToken);
        }
    }
}
