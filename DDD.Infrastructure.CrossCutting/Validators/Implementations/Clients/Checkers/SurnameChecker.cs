using System;
using DDD.Domain.Model.DTOs;
using DDD.Infrastructure.CrossCutting.Validators.Abstractions;

namespace DDD.Infrastructure.CrossCutting.Validators.Implementations.Clients.Checkers
{
    public class SurnameChecker : IValidationChecker<ClientDto>
    {
        public bool IsValid(ClientDto input)
        {
            var result = true;

            try
            {
                result = !string.IsNullOrEmpty(input?.Surname);
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
    }
}