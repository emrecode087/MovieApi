using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandler
{
    internal class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
    {
        private readonly MovieContext _context;

        public UpdateCastCommandHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Casts.FindAsync(request.CastId);
            values.Surname = request.Surname;
            values.Name = request.Name;
            values.Title = request.Title;
            values.Biography = request.Biography;
            values.ImageUrl = request.ImageUrl;
            values.Overview = request.Overview;
            await _context.SaveChangesAsync();

        }
    }
}
