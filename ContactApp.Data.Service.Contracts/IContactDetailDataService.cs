using ContactApp.Framework.Extentions;
using ContactMS.Data.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Data.Service.Contracts
{
    public interface IContactDetailDataService
    {
        Task<ActionStatus<IContactDetail>> CreateContactDetail(IContactDetail result);
        Task<ActionStatus<IContactDetail>> EditContactDetail(IContactDetail result);
        //Task<ActionStatus<IContactDetail>> DeleteContactDetail(int id);
    }
}
