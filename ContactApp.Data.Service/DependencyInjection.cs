using ContactApp.Data.Service.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Data.Service
{
    public static partial class DependencyInjection
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            _ = services.AddScoped<IContactDataService, ContactDataService>();
            _ = services.AddScoped<IContactDetailDataService, ContactDetailDataService>();
            return services;
        }
    }
}
