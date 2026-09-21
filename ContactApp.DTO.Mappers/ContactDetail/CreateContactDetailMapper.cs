using ContactApp.DTOs.ContactDetail;
using ContactApp.Framework.Mappers;
using ContactMS.Data.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.DTO.Mappers.ContactDetail
{
    public class CreateContactDetailMapper : APIDataMapper<IContactDetail, CreateContactDetailDTO>
    {
        public CreateContactDetailMapper(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        public override IContactDetail ToEntity(CreateContactDetailDTO value)
        {
            IContactDetail entity = this.CreateEntity();
            entity.ContactId = value.ContactId;
            entity.ContactNumber = value.ContactNumber;
            entity.CreatedUserId = value.CreatedUserId;
            return entity;
        }

        public override CreateContactDetailDTO ToObject(IContactDetail? entity)
        {
            CreateContactDetailDTO value = new CreateContactDetailDTO();
            value.ContactId = entity.ContactId;
            value.ContactNumber = entity.ContactNumber;
            value.CreatedUserId = entity.CreatedUserId;
            return value;
        }
    }
}