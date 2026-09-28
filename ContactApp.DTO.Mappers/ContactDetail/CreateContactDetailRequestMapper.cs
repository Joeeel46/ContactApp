using ContactApp.DTOs.ContactDetail;
using ContactApp.Framework.Mappers;
using ContactMS.Data.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.DTO.Mappers.ContactDetail
{
    public class CreateContactDetailRequestMapper : APIDataMapper<IContactDetail, CreateContactDetailRequestDTO>
    {
        public CreateContactDetailRequestMapper(IServiceProvider serviceProvider): base(serviceProvider)
        {
        }

        public override IContactDetail ToEntity(CreateContactDetailRequestDTO value)
        {
            IContactDetail entity = this.CreateEntity();

            entity.ContactNumber = value.ContactNumber;
            entity.CreatedUserId = value.CreatedUserId;

            return entity;
        }

        public override CreateContactDetailRequestDTO? ToObject(
            IContactDetail? value)
        {
            if (value == null)
                return null;

            return new CreateContactDetailRequestDTO
            {
                ContactNumber = value.ContactNumber,
                CreatedUserId = value.CreatedUserId
            };
        }
    }
}
