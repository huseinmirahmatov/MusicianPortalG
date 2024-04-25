using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Contracts.Requests.Genre
{
    public class UpdateGenreRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public GenreType Type { get; set; }
    }
}
