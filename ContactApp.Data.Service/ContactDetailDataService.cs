using ContactApp.Data.Service.Contracts;
using ContactApp.Framework;
using ContactApp.Framework.Data;
using ContactApp.Framework.Data.Service;
using ContactApp.Framework.Extentions;
using ContactMS.Data.Contract;
using Microsoft.EntityFrameworkCore;
using ProductMS.Framework.Extensions;
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

        public async Task<ActionStatus<List<IContactDetail>>> CreateContactDetails(List<IContactDetail> detailmodel)
        {
            try
            {
                _contactDetailRepository.Insert(detailmodel);

                int count = await UnitOfWork.CommitAsync();

                if (count > 0)
                {
                    return new ActionStatus<List<IContactDetail>>(true,detailmodel);
                }

                return new ActionStatus<List<IContactDetail>>(new ResponseVM("DPC0001"));
            }
            catch (Exception ex)
            {
                return new ActionStatus<List<IContactDetail>>("DPC-CreateContactDetails", ex);
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

        public async Task<ActionStatus<IContactDetail>> GetContactDetailById(long id)
        {
            try
            {
                IContactDetail? contactDetail = await _contactDetailRepository.Entities.FirstOrDefaultAsync(x => x.Id == id);

                if (contactDetail != null)
                {
                    return new ActionStatus<IContactDetail>(true,contactDetail);
                }

                return new ActionStatus<IContactDetail>(new ResponseVM("CONTACTDETAIL_NOT_FOUND"));
            }
            catch (Exception ex)
            {
                return new ActionStatus<IContactDetail>("DSE-GetContactDetailById", ex);
            }
        }

        public async Task<ActionStatus<List<IContactDetail>>> GetContactDetailsByContactId(long contactId)
        {
            try
            {
                List<IContactDetail> result = await _contactDetailRepository.Entities
                        .Where(x => x.ContactId == contactId)
                        .ToListAsync();

                return new ActionStatus<List<IContactDetail>>(true, result);
            }
            catch (Exception ex)
            {
                return new ActionStatus<List<IContactDetail>>(
                    "DSE-GetContactDetailsByContactId", ex);
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
