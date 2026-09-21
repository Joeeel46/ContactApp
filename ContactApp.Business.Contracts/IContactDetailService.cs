using ContactApp.DTOs.Contact;
using ContactApp.DTOs.ContactDetail;
using ContactApp.Framework.Extentions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Business.Contracts
{
    public interface IContactDetailService
    {
        Task<ActionStatus<ContactDetailDTO>> CreateContactDetail(CreateContactDetailDTO dto);
        Task<ActionStatus<ContactDetailDTO>> EditContactDetail(EditContactDetailDTO dto);
        //Task<ActionStatus<ContactDetailDTO>> DeleteContactDetail(int id);
    }
}
