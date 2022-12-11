using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices;

public static class IServiceCollectionExtension
{
    public static void AddAppServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IDonationService, DonationService>();
        serviceCollection.AddScoped<IRaiseService, RaisService>();
        serviceCollection.AddScoped<IFundraisingGroupService, FundraisingGroupService>();
        serviceCollection.AddScoped<IpermissionsService, PermissionsService>();
        serviceCollection.AddScoped<ITargetsService, TargetsService>();
        serviceCollection.AddAutoMapper(config=>config.AddProfile<DonationProfile>());
        serviceCollection.AddAutoMapper(config => config.AddProfile<TargetsProfile>());
        serviceCollection.AddAutoMapper(config => config.AddProfile<FundraisingGroupProfile>());
        serviceCollection.AddAutoMapper(config => config.AddProfile<RaisProfile>());
        //serviceCollection.AddDbContext<MatchingContext>(opt=>opt.UseSqlServer)
        serviceCollection.AddRepositories();
    }
}
