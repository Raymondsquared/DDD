using DDD.Domain.Model.DTOs;
using DDD.Infrastructure.CrossCutting.Abstractions;

namespace DDD.Infrastructure.CrossCutting.Validators.Abstractions
{
    public interface IClientValidator : IValidator<ClientDto>
    {
    }
}
