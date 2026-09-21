using ContactApp.DTOs.Contact;
using ContactApp.Framework.Mappers;
using ContactMS.Data.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.DTO.Mappers.Contact
{
    public class EditContactMapper : APIDataMapper<IContact, EditContactDTO>
    {
        public EditContactMapper(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override IContact ToEntity(EditContactDTO value)
        {
            IContact entity = this.CreateEntity();
            entity.Id = value.Id;
            entity.Name = value.Name;
            entity.isActive = value.isActive;
            entity.EditedUserId = value.EditedUserId;
            return entity;
        }

        public override EditContactDTO ToObject(IContact? entity)
        {
            EditContactDTO value = new EditContactDTO();
            value.Id = entity.Id;
            value.Name = entity.Name;
            value.isActive = entity.isActive;
            value.EditedUserId = entity.EditedUserId;
            return value;
        }
    }
}
