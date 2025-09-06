using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext _context;

        public GetMovieByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery query)
        {
            var value = await _context.Movies.FindAsync();
            if(value == null)
            {
                throw new KeyNotFoundException($"Movie with id {query.MovieId} not found.");
            }
            else
            {
                return new GetMovieByIdQueryResult
                {
                    MovieId = value.MovieId,
                    MovieTitle = value.MovieTitle,
                    CoverImageUrl = value.CoverImageUrl,
                    CreatedYear = value.CreatedYear,
                    Duration = value.Duration,
                    Description = value.Description,
                    Rating = value.Rating,
                    ReleaseDate = value.ReleaseDate,
                    Status = value.Status
                };
            }
        }
    }
}
