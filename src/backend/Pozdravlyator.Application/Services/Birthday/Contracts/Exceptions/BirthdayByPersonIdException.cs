using System;
using Pozdravlyator.Domain.Shared.Exceptions;

namespace Pozdravlyator.Application.Services.Image.Contracts.Exceptions
{
    public sealed class BirthdayByPersonIdException : NotFoundException
    {
        private const string MessageTemplate = "Не удалось найти День Рождения человека по его Id[{0}]";
        
        public BirthdayByPersonIdException(string PersonId) : base(string.Format(MessageTemplate, PersonId))
        {
        }
    }
}