using Pozdravlyator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pozdravlyator.Application.Services.Birthday.Contracts
{
    public static class Save
    {
        public sealed class Request
        {
            public int Id { get; set; }
            public int PersonId { get; set; }
            public DateOnly Date { get; set; }
        }
    }
}
