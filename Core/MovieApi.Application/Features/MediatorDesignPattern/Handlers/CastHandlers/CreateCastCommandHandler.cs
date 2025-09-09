using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
    {
        private readonly MovieContext _context;

        public CreateCastCommandHandler(MovieContext movieContext)
        {
            _context = movieContext;
        }

        public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {
            _context.Casts.Add(new Cast
            {
                Biography = request.Biography,
                ImageUrl = request.ImageUrl,
                Title = request.Title,
                Name = request.Name,
                Surname = request.Surname,
                Overview = request.Overview
            });
            await _context.SaveChangesAsync();
        }


    }
}
