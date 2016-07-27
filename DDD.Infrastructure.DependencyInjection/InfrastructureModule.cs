using Autofac;
using DDD.Domain.Model;
using DDD.Infrastructure.CrossCutting.Abstractions;
using DDD.Infrastructure.Mock;

namespace DDD.Infrastructure.DependencyInjection
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            /* Repositories */
            builder.RegisterType<MockUserRepository>()
                .As<IRepository<User>>();
        }
    }
}
