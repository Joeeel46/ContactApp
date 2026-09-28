using ContactApp.DTOs.Contact;
using ContactApp.Framework.Mappers;
using ContactMS.Data.Contract;
using System;

namespace ContactApp.DTO.Mappers.Contact
{
    public class CreateContactRequestMapper: APIDataMapper<IContact, CreateContactRequestDTO>
    {
        public CreateContactRequestMapper(IServiceProvider serviceProvider): base(serviceProvider)
        {
        }

        public override IContact ToEntity(CreateContactRequestDTO value)
        {
            IContact entity = this.CreateEntity();

            entity.Name = value.Name;
            entity.isActive = value.isActive;
            entity.CreatedUserId = value.CreatedUserId;

            return entity;
        }

        public override CreateContactRequestDTO? ToObject(IContact? value)
        {
            if (value == null)
                return null;

            return new CreateContactRequestDTO
            {
                Name = value.Name,
                isActive = value.isActive,
                CreatedUserId = value.CreatedUserId
            };
        }
    }
}