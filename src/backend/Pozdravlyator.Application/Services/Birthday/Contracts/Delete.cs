using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pozdravlyator.Application.Services.Birthday.Contracts
{
    public static class Delete
    {
        public sealed class Request
        {
            public int Id{ get; set; }
        }
    }
}
