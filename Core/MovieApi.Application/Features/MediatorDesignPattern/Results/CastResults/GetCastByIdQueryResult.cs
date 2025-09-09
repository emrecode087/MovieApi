using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults
{
    public class GetCastByIdQueryResult
    {
        public int CastId { get; set; }
        public int Title { get; set; }
        public int Name { get; set; }
        public int Surname { get; set; }
        public int ImageUrl { get; set; }
        public string? Overview { get; set; }
        public string? Biography { get; set; }
    }
}
