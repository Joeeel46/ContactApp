using ContactApp.Framework;
using ContactApp.Framework.Data;
using ContactMS.Data.Contract;
using ContactMS.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactMS.Data
{
    public static partial class DependencyInjection
    {
        public static IServiceCollection AddEntities(this IServiceCollection services)
        {
            services.AddScoped<DbContext, ContactMSContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            _ = services.AddTransient<IContact, Contact>();
            _ = services.AddTransient<IContactDetail, ContactDetail>();

            return services;
        }
    }
}
