using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _context;

        public UpdateMovieCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateMovieCommand command)
        {
            var value = await _context.Movies.FindAsync(command.MovieId);
            
            if(value == null)
            {
                throw new KeyNotFoundException($"Movie with id {command.MovieId} not found.");

            }
            else
            {
                value.Rating = command.Rating;
                value.Status = command.Status;
                value.MovieTitle = command.MovieTitle;
                value.Duration = command.Duration;
                value.CoverImageUrl = command.CoverImageUrl;
                value.Description = command.Description;
                value.ReleaseDate = command.ReleaseDate;
                await _context.SaveChangesAsync();
            }

        }
    }
}
