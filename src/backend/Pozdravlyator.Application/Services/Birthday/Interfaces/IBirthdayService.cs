using Pozdravlyator.Application.Services.Birthday.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pozdravlyator.Application.Services.Birthday.Interfaces
{
    public interface IBirthdayService
    {
        Task<Create.Response> Create(Create.Request request, CancellationToken cancellationToken);
        Task<Get.Response> Get(Get.Request request, CancellationToken cancellationToken);
        Task Save(Save.Request request, CancellationToken cancellationToken);
        Task Delete(Delete.Request request, CancellationToken cancellationToken);
        Task Upload(Upload.Request request, CancellationToken cancellationToken);
    }
}
