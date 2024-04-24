using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.Genre
{
    public class CreateGenreRequest
    {
        public string Name { get; set; }
        public GenreType Type { get; set; }
    }
}
