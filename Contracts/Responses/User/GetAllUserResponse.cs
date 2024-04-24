using Contracts.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses.User
{
    public class GetAllUserResponse
    {
        public IEnumerable<SingleUserResponse> Items { get; set; } = Enumerable.Empty<SingleUserResponse>();
    }
}
