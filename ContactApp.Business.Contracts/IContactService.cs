using ContactApp.DTOs.Contact;
using ContactApp.Framework.Extentions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Business.Contracts
{
    public interface IContactService
    {
        Task<ActionStatus<ContactDTO>> CreateContact(CreateContactDTO dto);
        Task<ActionStatus<ContactDTO>> EditContact(EditContactDTO dto);
    }
}
