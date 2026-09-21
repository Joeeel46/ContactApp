using ContactApp.DTOs.Contact;
using ContactApp.DTOs.ContactDetail;
using ContactApp.Framework.Mappers;
using ContactMS.Data.Contract;

namespace ContactApp.DTO.Mappers.ContactDetail
{
    public class ContactDetailMapper : APIDataMapper<IContactDetail, ContactDetailDTO>
    {
        public ContactDetailMapper(IServiceProvider Services) : base(Services)
        {
        }

        public override IContactDetail ToEntity(ContactDetailDTO value)
        {
            IContactDetail entity = this.CreateEntity();
            entity.Id = value.Id;
            entity.ContactId = value.ContactId;
            entity.ContactNumber = value.ContactNumber;
            entity.CreatedUserId = value.CreatedUserId;
            entity.EditedUserId = value.EditedUserId;
            entity.CreatedDate = value.CreatedDate;
            entity.EditedDate = value.EditedDate;
            return entity;
        }

        public override ContactDetailDTO ToObject(IContactDetail? entity)
        {
            ContactDetailDTO value = new ContactDetailDTO();
            value.Id = entity.Id;
            value.ContactId = entity.ContactId;
            value.ContactNumber = entity.ContactNumber;
            value.CreatedUserId = entity.CreatedUserId;
            value.EditedUserId = entity.EditedUserId;
            value.CreatedDate = entity.CreatedDate;
            value.EditedDate = entity.EditedDate;
            return value;
        }
    }
}
