using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pozdravlyator.Domain;

namespace Pozdravlyator.Application.Services.Birthday.Contracts
{
    public static class Create
    {
        public sealed class Request
        {
            public Person Person { get; set; }

            // public string Name { get; set; }
            // public int Age { get; set; }
            public DateOnly Date { get; set; }
        }

        public sealed class Response
        {
            public int Id { get; set; }
        }
    }
}
