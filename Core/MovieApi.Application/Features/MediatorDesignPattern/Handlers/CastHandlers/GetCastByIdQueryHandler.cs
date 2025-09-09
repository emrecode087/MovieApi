﻿using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandler
{
    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly MovieContext _context;

        public GetCastByIdQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            var values =await _context.Casts.FindAsync(request.CastId);
            return new GetCastByIdQueryResult
            {
                Biography = values.Biography,
                ImageUrl = values.ImageUrl,
                CastId = values.CastId,
                Name = values.Name,
                Surname = values.Surname,
                Overview = values.Overview,
                Title = values.Title
            };
        }
    }
}
