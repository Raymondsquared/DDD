using System;
using System.Collections.Generic;
using DDD.Domain.Model.DTOs;
using DDD.Infrastructure.CrossCutting.Abstractions;
using DDD.Infrastructure.CrossCutting.Validators.Abstractions;

namespace DDD.Infrastructure.CrossCutting.Validators.Implementations.Clients
{
    public class ClientValidator : IValidator<ClientDto>
    {
        private readonly IEnumerable<IValidationChecker<ClientDto>> _checkers;

        public ClientValidator(IEnumerable<IValidationChecker<ClientDto>> checkers)
        {
            _checkers = checkers;
        }

        public bool IsValid(ClientDto input)
        {
            var result = true;

            try
            {
                foreach (var checker in _checkers)
                {
                    if (!checker.IsValid(input))
                    {
                        result = false;
                        break; ;
                    }
                }
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
    }
}