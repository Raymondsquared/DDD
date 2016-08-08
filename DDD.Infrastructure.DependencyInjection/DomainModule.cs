using Autofac;
using DDD.Domain.Model;
using DDD.Domain.Model.DTOs;
using DDD.Domain.Service.Abstractions;
using DDD.Domain.Service.Implementations;
using DDD.Infrastructure.CrossCutting.Abstractions;

namespace DDD.Infrastructure.DependencyInjection
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            /* Service */
            builder.RegisterType<ClientService>()
                .As<IDomainService<ClientDto>>();

            builder.RegisterType<UserService>()
                .As<IDomainService<User>>()
                .As<IUserService>();            
        }
    }
}
