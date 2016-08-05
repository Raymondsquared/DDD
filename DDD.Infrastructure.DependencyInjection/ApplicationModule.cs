using Autofac;
using Autofac.Core;
using DDD.Application.Abstractions;
using DDD.Application.Implementation;
using DDD.Application.Services.Abstractions;
using DDD.Application.Services.Implementations;
using DDD.Infrastructure.CrossCutting;
using DDD.Infrastructure.CrossCutting.Helpers;
using DDD.Infrastructure.CrossCutting.Models.Configurations;
using DDD.Infrastructure.CrossCutting.Retries.Abstractions;
using DDD.Infrastructure.CrossCutting.Retries.Implementations;

namespace DDD.Infrastructure.DependencyInjection
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            /* Configs */
            var retryConfig = new RetryConfiguration() {
                Maximum = ConfigHelper.LoadOrDefault("Retry.Maximum", Constants.Defaults.Retry.Maximum),
                DelayMillseconds = ConfigHelper.LoadOrDefault("Retry.DelayMillseconds", Constants.Defaults.Retry.DelayMillseconds)
            };

            var batchConfig = new BatchConfiguration() {
                Size = ConfigHelper.LoadOrDefault("Batch.Size", Constants.Defaults.Retry.Maximum)
            };
            
            builder.RegisterInstance(batchConfig).As<BatchConfiguration>();

            /* Retry Strategies */
            builder.RegisterType<SimpleRetryStrategy>()
                .As<IRetryStrategy>()
                .WithParameter("retryConfig", retryConfig)
                .Keyed<IRetryStrategy>("simple");
            
            /* Service */
            builder.RegisterType<LogService>()
                .As<ILogService>();
            
            /* Console Application */
            builder.RegisterType<ConsoleApplicationService>()
                .As<IConsoleApplicationService>()
                .WithParameter(
                    new ResolvedParameter(
                        (pi, ctx) => pi.ParameterType == typeof(IRetryStrategy),
                        (pi, ctx) => ctx.ResolveKeyed<IRetryStrategy>("simple")));
        }
    }
}
