using ApiCodeChallenge.Common.Interfaces;
using ApiCodeChallenge.Repositories;
using ApiCodeChallenge.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCodeChallenge.Extension
{
    [ExcludeFromCodeCoverage]
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDependenciesForInjection(this IServiceCollection serviceCollection)
        {
            //Services
            // new instances
            serviceCollection.TryAddTransient<ITrainersService, TrainersService>();

            // vs scoped (singleton)
            //serviceCollection.TryAddScoped<ITrainersService, TrainersService>();

            //Repos
            serviceCollection.TryAddTransient<ITrainersRepo, TrainersRepo>();

            return serviceCollection;
        }
    }
}
