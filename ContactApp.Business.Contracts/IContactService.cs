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
        Task<ActionStatus<ContactDTO>> CreateContactWithDetails(CreateContactRequestDTO dto);
        Task<ActionStatus<ContactDTO>> GetContactById(long id);
        Task<ActionStatus<ContactDTO>> GetContactAndDetailsById(long id);
        Task<ActionStatus<ContactDTO>> BlockContact(long id);
        Task<ActionStatus<ContactDTO>> UnblockContact(long id);
        Task<ActionStatus<ContactDTO>> DeleteContact(long id);
    }
}
