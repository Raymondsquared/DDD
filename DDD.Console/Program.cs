using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using DDD.Application.Abstractions;
using DDD.Infrastructure.CrossCutting.Abstractions;
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
            System.Console.WriteLine("\n Running Syncronisation Process : \n");
            var syncApp = container.ResolveKeyed<IConsoleApplicationService>("synchronise");
            syncApp.RunWithRetryAsync().Wait();

            Parallel.Invoke(
                () => {
                    System.Console.WriteLine("\n Running Integration Process : \n");
                    var integrationApp = container.ResolveKeyed<IConsoleApplicationService>("integration");
                    integrationApp.RunWithRetryAsync().Wait();
                },
                () => {
                    System.Console.WriteLine("\n Running Query Process : \n");
                    var queryApp = container.ResolveKeyed<IConsoleApplicationService>("query");
                    queryApp.RunWithRetryAsync().Wait();
                }
            );
        }
    }
}
