using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public CreateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async void Handle(CreateMovieCommand command)
        {
            _context.Movies.Add(new Movie
            {

                CoverImageUrl = command.CoverImageUrl,
                MovieTitle = command.MovieTitle,
                CreatedYear = command.CreatedYear,
                Description = command.Description,
                Rating = command.Rating,
                ReleaseDate = command.ReleaseDate,
                Duration = command.Duration,
                Status = command.Status
            });
            await _context.SaveChangesAsync();
        }
    }
}
