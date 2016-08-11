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
            Parallel.Invoke(
                () => {
                    System.Console.WriteLine("Running Syncronisation Process ...");
                    var syncApp = container.ResolveKeyed<IConsoleApplicationService>("synchronise");
                    syncApp.RunWithRetryAsync().Wait();
                },
                () => {
                    System.Console.WriteLine("Running Integration Process : ...");
                    var integrationApp = container.ResolveKeyed<IConsoleApplicationService>("integration");
                    integrationApp.RunWithRetryAsync().Wait();
                },
                () => {
                    System.Console.WriteLine("Running Query Process : ...");
                    var queryApp = container.ResolveKeyed<IConsoleApplicationService>("query");
                    queryApp.RunWithRetryAsync().Wait();
                });
        }
    }
}
