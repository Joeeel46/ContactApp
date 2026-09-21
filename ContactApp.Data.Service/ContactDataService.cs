using ContactApp.Data.Service.Contracts;
using ContactApp.Framework.Data;
using ContactApp.Framework.Data.Entities;
using ContactApp.Framework.Data.Service;
using ContactApp.Framework.Extentions;
using ContactMS.Data.Contract;
using ProductMS.Framework.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Data.Service
{
    public class ContactDataService : BaseDataService, IContactDataService
    {
        IRepository<IContact> _contactRepository;
        public ContactDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _contactRepository = unitOfWork.Repository<IContact>();
        }

        public async Task<ActionStatus<IContact>> CreateContact(IContact result)
        {
            try
            {
                IContact data = _contactRepository.Add(result);
                int count = await UnitOfWork.CommitAsync();
                if (count > 0)
                {
                    return new ActionStatus<IContact>(true, data);
                }
                return new ActionStatus<IContact>(new ResponseVM("DPC0001"));
            }
            catch (Exception ex)
            {
                return new ActionStatus<IContact>("DSE-CreateContact", ex);
            }
        }

        public async Task<ActionStatus<IContact>> EditContact(IContact entity)
        {
            try
            {
                IContact data = await _contactRepository.Entities.FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (data != null)
                {
                    data.Name = entity.Name;
                    data.isActive = entity.isActive;
                    data.EditedUserId = entity.EditedUserId;
                    _contactRepository.Update(data);
                    int count = await UnitOfWork.CommitAsync();
                    if (count > 0)
                    {
                        return new ActionStatus<IContact>(true, data);
                    }
                    return new ActionStatus<IContact>(
                        new ResponseVM("DPE0001")
                    );
                }
                return new ActionStatus<IContact>(new ResponseVM("DPE0001"));
            }
            catch (Exception ex)
            {
                return new ActionStatus<IContact>("DPC-EditContact", ex);
            }
        }
    }
}
