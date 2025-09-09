using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries
{
    internal class GetTagQuery : IRequest<List<GetTagQueryResult>>
    {
        public int TagId { get; set; }
        public required string Title { get; set; }
    }
}
