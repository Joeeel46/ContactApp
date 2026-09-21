using ContactApp.Business.Contracts;
using ContactApp.Data.Service.Contracts;
using ContactApp.DTOs.Contact;
using ContactApp.Framework.Extentions;
using ContactApp.Framework.Mappers;
using ContactMS.Data.Contract;
using ProductMS.Framework.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Business
{
    public class ContactService : IContactService
    {

        IContactDataService _contactDataService;

        private readonly APIDataMapper<IContact, ContactDTO> _contactMapper;
        private readonly APIDataMapper<IContact, CreateContactDTO> _createContactMapper;
        private readonly APIDataMapper<IContact, EditContactDTO> _editContactMapper;
        public ContactService(IContactDataService contactDataService,
            APIDataMapper<IContact, ContactDTO> contactMapper,
            APIDataMapper<IContact, CreateContactDTO> createContactMapper,
            APIDataMapper<IContact, EditContactDTO> editContactMapper
            )
        {
            _contactDataService = contactDataService;
            _contactMapper = contactMapper;
            _createContactMapper = createContactMapper;
            _editContactMapper = editContactMapper;
        }

        public async Task<ActionStatus<ContactDTO>> CreateContact(CreateContactDTO dto)
        {
            try
            {
                IContact result = _createContactMapper.ToEntity(dto);
                ActionStatus<IContact> data = await _contactDataService.CreateContact(result);
                if (data)
                {
                    ContactDTO response = _contactMapper.ToObject(data.Result);

                    return new ActionStatus<ContactDTO>(true, response);
                }
                else if (data.HasException)
                {
                    return new ActionStatus<ContactDTO>(new ResponseVM("BPCE001"));
                }
                return new ActionStatus<ContactDTO>(data);
            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactDTO>("BPC-CreateContact", ex);
            }
        }

        public async Task<ActionStatus<ContactDTO>> EditContact(EditContactDTO dto)
        {
            try
            {
                IContact result = _editContactMapper.ToEntity(dto);
                ActionStatus<IContact> data = await _contactDataService.EditContact(result);
                if (data)
                {
                    ContactDTO response = _contactMapper.ToObject(data.Result);
                    return new ActionStatus<ContactDTO>(true, response);
                }
                else if (data.HasException)
                {
                    return new ActionStatus<ContactDTO>(new ResponseVM("BPCE002"));
                }
                return new ActionStatus<ContactDTO>(data);
            }
            catch (Exception ex)
            {
                return new ActionStatus<ContactDTO>("BPC-EditContact", ex);
            }
        }
    }
}
