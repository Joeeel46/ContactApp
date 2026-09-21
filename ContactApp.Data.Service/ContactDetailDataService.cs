using ContactApp.Data.Service.Contracts;
using ContactApp.Framework.Data;
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
    public class ContactDetailDataService : BaseDataService, IContactDetailDataService
    {
        IRepository<IContactDetail> _contactDetailRepository;
        public ContactDetailDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _contactDetailRepository = unitOfWork.Repository<IContactDetail>();
        }

        public async Task<ActionStatus<IContactDetail>> CreateContactDetail(IContactDetail result)
        {
            try
            {
                IContactDetail data = _contactDetailRepository.Add(result);
                int count = await UnitOfWork.CommitAsync();
                if (count > 0)
                {
                    return new ActionStatus<IContactDetail>(true, data);
                }
                return new ActionStatus<IContactDetail>(new ResponseVM("DPC0001"));
            }
            catch (Exception ex)
            {
                return new ActionStatus<IContactDetail>("DSE-CreateContactDetail", ex);
            }
        }

        public async Task<ActionStatus<IContactDetail>> EditContactDetail(IContactDetail entity)
        {
            try
            {
                IContactDetail data = await _contactDetailRepository.Entities.FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (data != null)
                {
                    data.ContactId = entity.ContactId;
                    data.ContactNumber = entity.ContactNumber;
                    data.EditedUserId = entity.EditedUserId;
                    _contactDetailRepository.Update(data);
                    int count = await UnitOfWork.CommitAsync();
                    if (count > 0)
                    {
                        return new ActionStatus<IContactDetail>(true, data);
                    }
                    return new ActionStatus<IContactDetail>(
                        new ResponseVM("DPE0001")
                    );
                }
                return new ActionStatus<IContactDetail>(new ResponseVM("DPE0001"));
            }
            catch (Exception ex)
            {
                return new ActionStatus<IContactDetail>("DPC-EditContactDetail", ex);
            }
        }

        //public async Task<ActionStatus<IContactDetail>> DeleteContactDetail(int id)
        //{
        //    try
        //    {
        //        IContactDetail data = await _contactDetailRepository.GetByIdAsync(id);
        //        if (data != null)
        //        {
        //            _contactDetailRepository.Delete(data);
        //            int count = await UnitOfWork.CommitAsync();
        //            if (count > 0)
        //            {
        //                return new ActionStatus<IContactDetail>(true, data);
        //            }
        //            return new ActionStatus<IContactDetail>(
        //                new ResponseVM("DPE0002")
        //            );
        //        }
        //        return new ActionStatus<IContactDetail>((ActionStatus)data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ActionStatus<IContactDetail>("DPC-DeleteContactDetail", ex);
        //    }
        //}
    }
}
