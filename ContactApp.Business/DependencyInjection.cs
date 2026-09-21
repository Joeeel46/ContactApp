
using ContactApp.Business.Contracts;
using Microsoft.Extensions.DependencyInjection;


namespace ContactApp.Business
{
    public static partial class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            _ = services.AddScoped<IContactService, ContactService>();
            _ = services.AddScoped<IContactDetailService, ContactDetailService>();
            return services;
        }
    }
}
