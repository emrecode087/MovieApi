using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Domain.Entities
{
    public class Cast
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
