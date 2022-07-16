using Pozdravlyator.Application.Repositories;
using Pozdravlyator.Application.Services.Birthday.Contracts;
using Pozdravlyator.Application.Services.Birthday.Interfaces;
using Pozdravlyator.Application.Services.Image.Contracts.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pozdravlyator.Application.Services.Birthday.Implementations
{
    public class BirthdayService: IBirthdayService
    {
        private readonly IRepository<Domain.Birthday, int> _repository;
        private readonly IBirthdayService _birthdayService;

        public BirthdayService(
            IRepository<Domain.Birthday, int> repository,
            IBirthdayService birthdayService
            )
        {
            _repository = repository;
            _birthdayService = birthdayService;
        }
        public async Task<Get.Response> Get(Get.Request request, CancellationToken cancellationToken)
        {
            Domain.Birthday birthday = null;

            if (request.PersonId != 0)
            {
                birthday = await _repository.FindWhere(x => x.PersonId == request.PersonId, cancellationToken);
            }
            if (birthday == null)
            {
                throw new BirthdayByPersonIdException(request.PersonId.ToString());
            }

            return new Get.Response
            {
                Id = birthday.Id,
                Person = birthday.Person,
                Date = birthday.Date,
            };
        }

        public async Task Save(Save.Request request, CancellationToken cancellationToken)
        {
            var birthday = new Domain.Birthday()
            {
                Id = request.Id,
                PersonId = request.PersonId,
                Date = request.Date
            };
            await _repository.Save(birthday, cancellationToken);
        }

        public async Task Upload(Upload.Request request, CancellationToken cancellationToken)
        {
            var birthday= new Domain.Birthday()
            {
                Id = request.Id,
                PersonId = request.PersonId,
                Date = request.Date
            };
            await _repository.Save(birthday, cancellationToken);
        }

        public async Task Delete(Delete.Request request, CancellationToken cancellationToken)
        {
            var birthday = await _repository.FindById(request.Id, cancellationToken);
            if (birthday == null)
            {
                throw new BirthdayByIdNotFoundException(request.Id.ToString());
            }

            await _repository.Delete(birthday, cancellationToken);
        }

        public async Task<Create.Response> Create(Create.Request request, CancellationToken cancellationToken)
        {
            var birthday = new Domain.Birthday
            {
                Person = request.Person,
                //={
                //    Name = request.Name,
                //    Age = request.Age,
                //},
                Date = request.Date,
            };
            await _repository.Save(birthday, cancellationToken);

            return new Create.Response
            {
                Id = birthday.Id
            };
        }
    }
}
