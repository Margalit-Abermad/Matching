using Microsoft.Extensions.DependencyInjection;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;

public static class IServiceCollectionExtension
{
    public static void AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IDonationRepository, DonationRepository>();
        serviceCollection.AddScoped<IFundraisingGroupRepository, FundraisingGroupRepository>();
        serviceCollection.AddScoped<IRaiseRepository, RaiseRepository>();
        serviceCollection.AddScoped<IPermissionsRepository, PermissionsRepository>();
        serviceCollection.AddScoped<ITargetRepository, TargetsRepository>();
        serviceCollection.AddDbContext<MatchingContext>();
    }
}
