using ContactApp.Framework.Extentions;
using ContactMS.Data.Contract;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace ContactApp.Data.Service.Contracts
{
    public interface IContactDataService
    {
        Task<ActionStatus<IContact>> CreateContact(IContact result);
        Task<ActionStatus<IContact>> EditContact(IContact result);
        Task<ActionStatus<IContact>> GetContactById(long id);
        Task<ActionStatus<IContact>> BlockContact(long id);
        Task<ActionStatus<IContact>> UnblockContact(long id);
        Task<ActionStatus<IContact>> DeleteContact(long id);
    }
}
