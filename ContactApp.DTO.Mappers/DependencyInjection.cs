using ContactApp.DTO.Mappers.Contact;
using ContactApp.DTO.Mappers.ContactDetail;
using ContactApp.DTOs.Contact;
using ContactApp.DTOs.ContactDetail;
using ContactApp.Framework.Mappers;
using ContactMS.Data.Contract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.DTO.Mappers
{
    public static partial class DependencyInjection
    {
        public static IServiceCollection AddDTOMappers(this IServiceCollection services)
        {
            services.AddScoped<APIDataMapper<IContact, ContactDTO>, ContactMapper>();
            services.AddScoped<APIDataMapper<IContact, CreateContactDTO>, CreateContactMapper>();
            services.AddScoped<APIDataMapper<IContact, EditContactDTO>, EditContactMapper>();
           
            services.AddScoped<APIDataMapper<IContactDetail, ContactDetailDTO>,ContactDetailMapper>();

            services.AddScoped<APIDataMapper<IContactDetail, CreateContactDetailDTO>,CreateContactDetailMapper>();

            services.AddScoped<APIDataMapper<IContactDetail, EditContactDetailDTO>,EditContactDetailMapper>();

            return services;
        }
    }
}
