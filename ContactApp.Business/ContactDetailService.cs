using ContactApp.Business.Contracts;
using ContactApp.Data.Service.Contracts;
using ContactApp.DTOs.Contact;
using ContactApp.DTOs.ContactDetail;
using ContactApp.Framework.Extentions;
using ContactApp.Framework.Mappers;
using ContactMS.Data.Contract;
using ProductMS.Framework.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Business
{
    public class ContactDetailService : IContactDetailService
    {
        IContactDetailDataService _contactDetailDataService;
        private readonly APIDataMapper<IContactDetail, ContactDetailDTO> _contactDetailMapper;
        private readonly APIDataMapper<IContactDetail, CreateContactDetailDTO> _createContactDetailMapper;
        private readonly APIDataMapper<IContactDetail, EditContactDetailDTO> _editContactDetailMapper;
        public ContactDetailService(IContactDetailDataService contactDetailDataService,
            APIDataMapper<IContactDetail, ContactDetailDTO> contactDetailMapper,
            APIDataMapper<IContactDetail, CreateContactDetailDTO> createContactDetailMapper,
            APIDataMapper<IContactDetail, EditContactDetailDTO> editContactDetailMapper)
        {
            _contactDetailDataService = contactDetailDataService;
            _contactDetailMapper = contactDetailMapper;
            _createContactDetailMapper = createContactDetailMapper;
            _editContactDetailMapper = editContactDetailMapper;
        }

        public async Task<ActionStatus<ContactDetailDTO>> CreateContactDetail(CreateContactDetailDTO dto)
        {
            try
            {
                IContactDetail result = _createContactDetailMapper.ToEntity(dto);
                ActionStatus<IContactDetail> data = await _contactDetailDataService.CreateContactDetail(result);
                if (data)
                {
                    ContactDetailDTO response = _contactDetailMapper.ToObject(data.Result);

                    return new ActionStatus<ContactDetailDTO>(true, response);
                }
                else if (data.HasException)
                {
                    return new ActionStatus<ContactDetailDTO>(new ResponseVM("BPCE001"));
                }
                return new ActionStatus<ContactDetailDTO>(data);
            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactDetailDTO>("BPC-CreateContact", ex);
            }
        }

        public async Task<ActionStatus<ContactDetailDTO>> EditContactDetail(EditContactDetailDTO dto)
        {
            try
            {
                IContactDetail result = _editContactDetailMapper.ToEntity(dto);
                ActionStatus<IContactDetail> data = await _contactDetailDataService.EditContactDetail(result);
                if (data)
                {
                    ContactDetailDTO response = _contactDetailMapper.ToObject(data.Result);
                    return new ActionStatus<ContactDetailDTO>(true, response);
                }
                else if (data.HasException)
                {
                    return new ActionStatus<ContactDetailDTO>(new ResponseVM("BPCE002"));
                }
                return new ActionStatus<ContactDetailDTO>(data);
            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactDetailDTO>("BPC-EditContact", ex);
            }
        }
    }
}
