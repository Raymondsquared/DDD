using Autofac;
using DDD.Domain.Model;
using DDD.Domain.Service.Implementations;
using DDD.Infrastructure.CrossCutting.Abstractions;

namespace DDD.Infrastructure.DependencyInjection
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            /* Service */
            builder.RegisterType<UserService>()
                .As<IDomainService<User>>();
        }
    }
}
