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
    }
}
