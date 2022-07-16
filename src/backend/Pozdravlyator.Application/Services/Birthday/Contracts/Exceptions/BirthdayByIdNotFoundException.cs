using System;
using Pozdravlyator.Domain.Shared.Exceptions;

namespace Pozdravlyator.Application.Services.Image.Contracts.Exceptions
{
    public sealed class BirthdayByIdNotFoundException : NotFoundException
    {
        private const string MessageTemplate = "Не удалось найти День Рождения по Id[{0}]";
        
        public BirthdayByIdNotFoundException(string Id) : base(string.Format(MessageTemplate, Id))
        {
        }
    }
}