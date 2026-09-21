using ContactApp.DTOs.ContactDetail;
using ContactApp.Framework.Mappers;
using ContactMS.Data.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.DTO.Mappers.ContactDetail
{
    public class EditContactDetailMapper : APIDataMapper<IContactDetail, EditContactDetailDTO>
    {
        public EditContactDetailMapper(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        public override IContactDetail ToEntity(EditContactDetailDTO value)
        {
            IContactDetail entity = this.CreateEntity();
            entity.Id = value.Id;
            entity.ContactId = value.ContactId;
            entity.ContactNumber = value.ContactNumber;
            entity.EditedUserId = value.EditedUserId;
            return entity;
        }

        public override EditContactDetailDTO ToObject(IContactDetail? entity)
        {
            EditContactDetailDTO value = new EditContactDetailDTO();
            value.Id = entity.Id;
            value.ContactId = entity.ContactId;
            value.ContactNumber = entity.ContactNumber;
            value.EditedUserId = entity.EditedUserId;
            return value;
        }
    }
}
