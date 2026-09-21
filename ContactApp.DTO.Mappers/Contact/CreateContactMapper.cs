using ContactApp.DTOs.Contact;
using ContactApp.Framework.Mappers;
using ContactMS.Data.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.DTO.Mappers.Contact
{
    public class CreateContactMapper : APIDataMapper<IContact, CreateContactDTO>
    {
        public CreateContactMapper(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
        public override IContact ToEntity(CreateContactDTO value)
        {
            IContact entity = this.CreateEntity();
            entity.Name = value.Name;
            entity.isActive = value.isActive;
            entity.CreatedUserId = value.CreatedUserId;
            return entity;
        }

        public override CreateContactDTO ToObject(IContact? entity)
        {
            CreateContactDTO value = new CreateContactDTO();
            value.Name = entity.Name;
            value.isActive = entity.isActive;
            value.CreatedUserId = entity.CreatedUserId;
            return value;
        }
    }
}

