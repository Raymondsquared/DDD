using Autofac;

namespace DDD.Infrastructure.DependencyInjection
{
    public class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterModule<InfrastructureModule>();
            builder.RegisterModule<DomainModule>();
            builder.RegisterModule<ApplicationModule>();
        }
    }
}
