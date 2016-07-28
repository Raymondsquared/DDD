﻿using Autofac;
using DDD.Domain.Model;
using DDD.Domain.Model.DTOs;
using DDD.Infrastructure.CrossCutting.Abstractions;
using DDD.Infrastructure.CrossCutting.Mappers.Abstractions;
using DDD.Infrastructure.CrossCutting.Mappers.Abstractions.DataSyncWorker.Mappers.Abstractions;
using DDD.Infrastructure.CrossCutting.Mappers.Implementations.ClientUser;
using DDD.Infrastructure.CrossCutting.Mappers.Implementations.ClientUser.Resolvers;
using DDD.Infrastructure.CrossCutting.Validators.Abstractions;
using DDD.Infrastructure.CrossCutting.Validators.Implementations.Clients;
using DDD.Infrastructure.CrossCutting.Validators.Implementations.Clients.Checkers;
using DDD.Infrastructure.Mock;

namespace DDD.Infrastructure.DependencyInjection
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            /* Validators */
            builder.RegisterType<FirstNameChecker>()
                .As<IValidationChecker<ClientDto>>();
            builder.RegisterType<SurnameChecker>()
                .As<IValidationChecker<ClientDto>>();

            builder.RegisterType<ClientValidator>()
                .As<IValidator<ClientDto>>();

            /* Mappers */
            builder.RegisterType<FirstNameResolver>()
                .As<IMapperResolver<ClientDto, User>>();
            builder.RegisterType<LastNameResolver>()
                .As<IMapperResolver<ClientDto, User>>();

            builder.RegisterType<ClientUserMapper>()
                .As<IMapper<ClientDto, User>>();

            /* Repositories */
            builder.RegisterType<MockUserRepository>()
                .As<IRepository<User>>();
        }
    }
}
