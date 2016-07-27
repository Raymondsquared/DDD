using Autofac;
using DDD.Application.Services.Abstractions;
using DDD.Infrastructure.DependencyInjection;

namespace DDD.Console
{
    public class Program
    {        
        public static void Main(string[] args)
        {
            /* Autofac */
            var builder = new ContainerBuilder();
            builder.RegisterModule<MainModule>();
            IContainer container = builder.Build();
            
            /* Application */
            var app = container.Resolve<IConsoleApplicationService>();
            app.RunWithRetryAsync().Wait();
        }
    }
}
